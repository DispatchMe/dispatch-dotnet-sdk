using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class CustomerResult : SingleRoot {

    [JsonProperty("customer")]
    public Customer Customer { get; set; }
  }
}
