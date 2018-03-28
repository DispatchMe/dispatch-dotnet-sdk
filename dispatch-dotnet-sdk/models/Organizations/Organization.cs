using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class Organization : ModelBase
  {

      [JsonProperty("email")]
      public string Email { get; set; }

      [JsonProperty("external_ids")]
      public List<string> ExternalIds { get; set; }

      [JsonProperty("logo_token")]
      public string LogoToken { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("phone_number")]
      public string PhoneNumber { get; set; }

  }
}
