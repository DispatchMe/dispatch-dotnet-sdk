using System;
using Newtonsoft.Json;

namespace Dispatch.Models
{
  public class ContactMethod
  {
    [JsonProperty("method")]
    public string Method { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("notify")]
    public bool Notify { get; set; }
  }
}
