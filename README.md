# SteamWebAPI2
[![Build Status](https://dev.azure.com/justinskiles/justinskiles/_apis/build/status/babelshift.SteamWebAPI2?branchName=master)](https://dev.azure.com/justinskiles/justinskiles/_build/latest?definitionId=2&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/SteamWebAPI2.svg)](https://www.nuget.org/packages/SteamWebAPI2)
[![MyGet CI](https://img.shields.io/myget/babelshift-ci/v/SteamWebAPI2.svg)](https://www.myget.org/feed/babelshift-ci/package/nuget/SteamWebAPI2)

This is a .NET library that makes it easy to use the Steam Web API. It conveniently wraps around all of the JSON data and ugly API details with clean methods, structures and classes.

Please refer [here](http://steamwebapi.azurewebsites.net/) for details regarding the Steam Web API, its endpoints, and how this library consumes them.

Check this README and the [Wiki](https://github.com/babelshift/SteamWebAPI2/wiki/) for more details about [getting started](https://github.com/babelshift/SteamWebAPI2/wiki/1.-Getting-Started) and [common use cases](https://github.com/babelshift/SteamWebAPI2/wiki/Common-Use-Examples).

## About this Library
This library was created to address the (at times) awful nature of the Steam Web API. Many of the exposed endpoints have little to no documentation on the parameters and absolutely no documentation on any of the responses. In addition, many of the endpoints do not follow any type of coding convention as it appears that different developers created different endpoints without collaborating with one another.

For example, some responses have a containing "response" object while others have a containing "result" object. To make it worse, some have a containing "results" or "responses" or "applist" or "playerstats" object or a number of other unconventional choices.

Instead of stressing about parsing the ugly JSON responses yourself, just use this library to make a method call and get back a response with everything in a more C#/.NET style. These are the rules on which the library was built:

  * Make the library as easy and user friendly as possible.
  * Document everything as thoroughly as possible.
  * Standardize all property names on returned JSON objects.
  * Deserialize UNIX TimeStamps to `DateTime`.
  * Deserialize "types" into `enum` where possible.
  * Clean up some of the more egregious JSON responses where JSON arrays should have been used but weren't.
  * Offer a sane way of handling the various representations and conversions of Steam ID by offering a SteamId class.
    * Handles legacy, modern, and 64-bit Steam Id representations
    
**NOTE:**
Valve's [Steamworks documentation](https://partner.steamgames.com/doc/webapi) doesn't do a good job at explaining the difference between their public API and partner API. This library only works with the public-facing API located at: `api.steampowered.com`. Any endpoints from their documentation that are located at the `partner.steam-api.com` will not be accessible with this library. I am not a registered publisher and thus don't have access to any of the partner endpoints.

## Install the Library from NuGet
See the library in the NuGet gallery [here](https://www.nuget.org/packages/SteamWebAPI2).

Package Manager:
```
Install-Package SteamWebAPI2 
```

.NET Core CLI:
```
dotnet add package SteamWebAPI2
```

## How to Use the Library
  1. Read the `About` section so you understand why this library exists
  2. Install the library from NuGet
  3. Get a Steam Web API developer key. [Get one here](https://steamcommunity.com/dev/apikey). **KEEP THIS SECRET**.
  4. Instantiate a `SteamWebInterfaceFactory` to use as a helper to create objects for various endpoint calls.
  5. Use the factory to create endpoint interface classes.
  5. Use the interface class and call a method with your parameters.

The library is structured to mirror the Steam Web API endpoint structure. For example, the "DOTA2Econ" class will expose methods to communicate with the "IDOTA2Econ" endpoints. See [here](http://steamwebapi.azurewebsites.net/) for more endpoint details.

Each method returns a SteamWebResponse object which contains the following:

| Field              | Type            | Description                                        |
|--------------------|-----------------|----------------------------------------------------|
| Data               | T               | Maps to the payload returned by the Steam Web API. |
| ContentLength      | long?           | Maps to the HTTP ContentLength header.             |
| ContentType        | string          | Maps to the HTTP ContentType header.               |
| ContentTypeCharSet | string          | Maps to the HTTP ContentType charset header.       |
| Expires            | DateTimeOffset? | Maps to the HTTP Expires header. Optional.         |
| LastModified       | DateTimeOffset? | Maps to the HTTP LastModified header. Optional     |

## Sample Usage

```cs
// factory to be used to generate various web interfaces
var webInterfaceFactory = new SteamWebInterfaceFactory(<dev api key here>);

// this will map to the ISteamUser endpoint
// note that you have full control over HttpClient lifecycle here
var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());

// this will map to ISteamUser/GetPlayerSummaries method in the Steam Web API
// see PlayerSummaryResultContainer.cs for response documentation
var playerSummaryResponse = await steamInterface.GetPlayerSummaryAsync(<steamIdHere>);
var playerSummaryData = playerSummaryResponse.Data;
var playerSummaryLastModified = playerSummaryResponse.LastModified;

// this will map to ISteamUser/GetFriendsListAsync method in the Steam Web API
// see FriendListResultContainer.cs for response documentation
var friendsListResponse = await steamInterface.GetFriendsListAsync(<steamIdHere>);
var friendsList = friendsListResponse.Data;
```
