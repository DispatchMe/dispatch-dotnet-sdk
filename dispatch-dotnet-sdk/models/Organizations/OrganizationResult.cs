using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class OrganzationResult : SingleRoot {

    [JsonProperty("organization")]
    public Organization Organization { get; set; }
  }
}
