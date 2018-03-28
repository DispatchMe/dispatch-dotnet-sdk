using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class BrandResult : SingleRoot {

    [JsonProperty("brand")]
    public Brand Brand { get; set; }
  }
}
