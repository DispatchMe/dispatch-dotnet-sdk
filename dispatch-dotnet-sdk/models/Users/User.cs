using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class User : ModelBase
  {
      [JsonProperty("email")]
      public string Email { get; set; }

      [JsonProperty("first_name")]
      public string FirstName { get; set; }

      [JsonProperty("last_name")]
      public string LastName { get; set; }

      [JsonProperty("phone_number")]
      public string PhoneNumber { get; set; }

      [JsonProperty("roles")]
      public IList<string> Roles { get; set; }
  }
}
