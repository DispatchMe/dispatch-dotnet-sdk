using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class Location {

    [JsonProperty("street_1")]
    public string Street1 { get; set; }

    [JsonProperty("street_2")]
    public string Street2 { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("postal_code")]
    public string PostalCode { get; set; }

    [JsonProperty("timezone")]
    public string TimeZone { get; set;}

  }

}
