using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class UserResult : SingleRoot {

    [JsonProperty("user")]
    public User User { get; set; }
  }
}
