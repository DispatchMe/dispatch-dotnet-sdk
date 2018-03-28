using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Dispatch;
using System.IO;

namespace DispatchWeb.Controllers
{
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
}
