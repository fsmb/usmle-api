# USMLE API Sample (C#)

[Run the Code](#run-the-code) \
[Using the Class Library](#using-the-class-library) \
[Change Log](#change-log)

This solution contains a simple test application for working with the API and a class library.

The console application demonstrates using the API to make calls. It demonstrates some of the more common requests.

*The code is an example of how you might use the API and has not been tested or hardened for production use.*

The class library contains auto-generated code to work with the API. The class library can be copied and used in your own project. The class library is multi-targeted for .NET 4.7.2 and .NET 8.0. If you are building .NET 4.7.2+ or .NET 6.0+ projects then the library should work out of the box.
If you are targeting a different version of .NET then you will need to adjust the project and code accordingly.

*Note: Visual Studio 2022 or later is required for .NET 8.0 support. If you are using an earlier version of Visual Studio you will need to adjust the project to target an older framework.*

## Run the Code

To run this sample do the following.

1. Download the entire solution directory to your local machine.
1. Open the solution (`.sln`) in Visual Studio.
1. Compile the solution.
1. Run the solution.

## Using the Class Library

To use the class library in your own code do the following.

1. Ensure either the project is part of your solution or build the project and reference the generated assembly in your solution.
1. In your application's startup code store the URL to the API (see the documentation), your client ID and client secret somewhere that your code has access to such as a configuration file or environment variable.
1. To call the API create an instance of the `UsmleApiClient` class and pass the configuration information stored earlier. See below for more information.     
1. Use the client to make calls to the API.
   ```
   //Assuming this code is called in an async function then use await to wait for the response
   Transcript transcript = await client.GetCurrentTranscriptAsync(usmleId).ConfigureAwait(false);
   ```

## Configuring the Client

For .NET Framework projects do the following.

```csharp
HttpClient httpClient = new HttpClient() {
    BaseAddress = new Uri("<url ending with slash>")
};
var credendentials = new UsmleApiClientCredentials() {
    ClientId = "clientId",
    ClientSecret = "clientSecret"
};
UsmleClient client = new UsmleApiClient(httpClient, credentials);
```

For .NET Core projects you should use dependency injection.

```csharp
//App startup code

//Configure the HTTP client
services.AddHttpClient("Usmle")
        .ConfigureHttpClient(client => {
            client.BaseAddress = new Uri("<url ending with slash>");
        });
       
//Configure the credentials to use
services.AddSingleton(new UsmleApiClientCredentials() {
    ClientId = "<client-id>",
    ClientSecret = "<client-secret>"
});

//Register the client
services.AddScoped<UsmleApiClient>(provider => {
    var options = provider.GetService<UsmleApiClientOptions>();
    var credentials = provider.GetRequiredService<UsmleApiClientCredentials>();

    var factory = provider.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("Usmle");

    return new UsmleApiClient(client, options, credentials);
});

//Code that uses client through DI
class FsmbService
{
   public FsmbService ( UsmleApiClient client )
   {
      _client = client;
   }

   private readonly UsmleApiClient _client;
}
```

*Note: It is strongly recommended that you create a single instance of the client and reuse it instead of creating a new instance each time.*

## Change Log

- 2025-Sept-23
  - Initial version
