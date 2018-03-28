using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class PhoneNumber {

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("primary")]
    public bool Primary { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
  }

}
