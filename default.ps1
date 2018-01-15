properties {
  $baseDir = resolve-path .
  $buildDir = "$baseDir\build"
  $sourceDir = "$baseDir\src"
  $artifactsDir = "$baseDir\artifacts"
  $global:config = "Debug"
}

task default -depends local
task local -depends init, compile
task ci -depends clean, release, local

task clean {
  Remove-Item "$artifactsDir" -recurse -force -ErrorAction SilentlyContinue | Out-Null
}

task init { 
  $isDotNetDownloaded = Test-Path dotnet-sdk.exe
  
  if($isDotNetDownloaded -eq $false) {
    Write-Output 'Did not find dotnet-sdk.exe. Starting download.'
	exec { curl -O dotnet-sdk.exe https://download.microsoft.com/download/0/F/D/0FD852A4-7EA1-4E2A-983A-0484AC19B92C/dotnet-sdk-2.0.0-win-x64.exe | Out-Default }
  } else {
	Write-Output 'Found dotnet-sdk.exe. Skipping download.'
  }
  
  Write-Output 'Installing dotnet-sdk.exe.'
  exec { .\dotnet-sdk.exe /install /quiet /norestart /log install.log | Out-Default }
  exec { dotnet --version | Out-Default }
}

task release {
  $global:config = "Release"
}

task compile -depends clean {
  $projectPath = "$sourceDir\SteamWebAPI2\SteamWebAPI2.csproj"

  $version = if ($env:APPVEYOR_BUILD_NUMBER -ne $NULL) { $env:APPVEYOR_BUILD_NUMBER } else { '0' }

  exec { dotnet restore $projectPath }
  exec { dotnet build $projectPath -c $config }

  if ($env:APPVEYOR_REPO_TAG -eq $true) {
    exec { dotnet pack $projectPath -c $config -o $artifactsDir }
  }
  else {
    exec { dotnet pack $projectPath -c $config -o $artifactsDir --version-suffix $version }
  }
}