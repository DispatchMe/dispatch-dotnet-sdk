using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class BrandList : ListRoot {

    [JsonProperty("brands")]
    public IEnumerable<Brand> Brands { get; set; }
  }

}
