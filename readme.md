# Dispatch .NET SDK (alpha)

## SDK

The .NET SDK contains a wrapper around the Dispatch REST API.  The following operations are currently supported:

### Client

The Client class is responsible for performaing API access.  It implements a series of individual entity-based interfaces.

```cs
public interface IBrandClient {

    Task<BrandList> ListBrandsAsync();

    ...
  }
```

All REST methods are awaitable.

### Constructor

The Client constructor accepts a base address, which defaults to https://api.dispatch.me, and a version, which defaults to v3.  For integration testing, the base address may be set to https://api-staging.dispatch.me.

```cs
//Constructor
public Client(string baseAddress = BASE_ADDRESS, string version = "v3")
{
  //
}
```

### Authentication

Currently, the .NET SDK supports only `client_credentials` authentication, using a `client_id` and `client_secret`.  This method must be called prior to any auth protected API calls, or requests will fail with an Unauthorized response code (401).

```cs
public async Task<BearerResponse> Authenticate(string clientID, string clientSecret)
{
    ...
}
```

Calling Authenticate will attach the bearer token to subsequent API calls.  This call also returns a `BearerResponse`, which may be interrogated to check for errors or get the actual Bearer value.

```cs
if (! bearer.HasError) {
  //Handle error
} else {
  //Access token values
}
```

### Entity Methods

Each restful endpoint is wrapped in an awaitable `Client` method.  For example, to work with Brands the following methods exist:

```cs
public async Task<BrandList> ListBrandsAsync()
{
  ...
}

public async Task<BrandResult> UpdateBrandAsync(int id, Dictionary<string, object> data)
{
    ...
}

public async Task DeleteBrandAsync(int id)
{
    ...
}
```

`Update*` methods require a `Dictionary<string, object>` to provide `PATCH` data.

### Build Source
The .NET SDK is built against dotnet core 2.1.x.  To build, run the dotnet command line as follows:

```bash
#from src
cd dispatch-dotnet-sdk
dotnet build
```

 ## Sample Web App

The repository contains a sample web app using the `reactredux` ASP.NET Core project template.  To run this project, use the following command:

```bash
#from src
cd dispatch-dotnet-sdk-web
dotnet run
```

This command will spin up a web server to run on port 5000.  Browse to http://localhost:5000 to view the web app.

### Client State

REST clients are generally designed to be stateless, and the Dispatch Client is no different. However, for the purpose of the sdk web sample, the Client is cached in a static variable in a `ControllerBase` class to avoid having to re-authenticate with each request.

Note that the `Client` instance expects to find configuration data in the `appsettings.json` file.  Also note that **the credentials in this file are not valid.**

```cs
public abstract class ControllerBase : Controller
{
  protected static Client _DispatchClient;

  static ControllerBase()
  {
    var config = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json").Build();

      var baseAddress = config["baseAddress"];
      var version = config["version"];
      _DispatchClient = new Client(baseAddress, version);

      var result = _DispatchClient.Authenticate(config["clientId"], config["clientSecret"]).Result;
      if (result.HasError) {
        Console.WriteLine(result.Error);
      }
  }
}
```

### Sample Controllers

The API calls from the react app are made via controllers in the ASP.NET app.

```cs
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IEnumerable<Brand>> Brands()
    {
        var list = await _DispatchClient.ListBrandsAsync();
        return list.Brands;
    }
}
```

### Single Page App

The react app contains a set of components - one for each entity.  Similarly, each entity is represented in the store.  See `ClientApp/components/BrandData.tsx` and `store/Brand.ts` respectively.  `store/index.ts` is where state is wired together for the client side app.

```typescript
export interface ApplicationState {
    counter: Counter.CounterState;
    brands: Brands.BrandState;
    organizations: Organizations.OrganizationState;
    users: Users.UserState;
}

export const reducers = {
    counter: Counter.reducer,
    brands: Brands.reducer,
    organizations: Organizations.reducer,
    users: Users.reducer,
};
```

State and reducers are defined in the individual ```<Entity>.ts``` file.
