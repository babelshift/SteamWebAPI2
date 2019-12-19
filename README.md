# SteamWebAPI2
[![Build status](https://ci.appveyor.com/api/projects/status/cga6ck03o286sq80?svg=true)](https://ci.appveyor.com/project/JustinSkiles/steamwebapi2)
[![NuGet](https://img.shields.io/nuget/v/SteamWebAPI2.svg)](https://www.nuget.org/packages/SteamWebAPI2)
[![MyGet CI](https://img.shields.io/myget/babelshift-ci/v/SteamWebAPI2.svg)](https://www.myget.org/feed/babelshift-ci/package/nuget/SteamWebAPI2)

This is a .NET library that makes it easy to use the Steam Web API. It conveniently wraps around all of the JSON data and ugly API details with clean methods, structures and classes.

Please refer [here](http://steamwebapi.azurewebsites.net/) for details regarding the Steam Web API, its endpoints, and how this library consumes them.

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

## Install the Library from NuGet
See the library in the NuGet gallery [here](https://www.nuget.org/packages/SteamWebAPI2). You can install the library into your project directly from the package manager.

```
Install-Package SteamWebAPI2 
```

## How to Use the Library
  1. Read the `About` section so you understand why this library exists
  2. Install the library from NuGet
  3. Get a Steam Web API developer key. [Get one here](https://steamcommunity.com/dev/apikey). **KEEP THIS SECRET**.
  4. Instantiate a `SteamWebInterfaceFactory` to use as a helper to create objects for various endpoint calls.
  5. Use the factory to create endpoint interface classes.
  5. Use the interface class and call a method with your parameters.

The library is structured to mirror the Steam Web API endpoint structure. For example, the "DOTA2Econ" class will expose methods to communicate with the "IDOTA2Econ" endpoints.

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

## Changes from 2.0 to 3.0
In versions previous to 3.0, numerical types were treated as short, int, and long. This caused problems when interacting with the Steam Web API because Valve accepts and returns unsigned numerical types. Instead of constantly reacting to overflows when a specific endpoint would return something outside the bounds of a 32-bit int, I decided to switch all numerical types to their unsigned counterparts.

## Changes from 3.0 to 4.0
  * .NET Core is now supported.
  * All endpoints now return ISteamWebResponse<T> where T is the response payload type. This allows more metadata to be returned with each end point such as HTTP headers and status messages in addition to the response payload.
