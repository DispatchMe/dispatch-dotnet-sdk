using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class Meta {

    [JsonProperty("limit")]
    public int Limit { get; set; }

    [JsonProperty("offset")]
    public int Offset { get; set;}

    [JsonProperty("total")]
    public int Total { get; set; }
  }

}
