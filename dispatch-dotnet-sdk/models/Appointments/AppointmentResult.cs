using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class AppointmentResult : SingleRoot {

    [JsonProperty("appointments")]
    public Brand Brand { get; set; }
  }
}
