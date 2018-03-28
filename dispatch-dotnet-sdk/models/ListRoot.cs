using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class ListRoot {

    [JsonProperty("meta")]
    public Meta Meta { get; set;}
  }

}
