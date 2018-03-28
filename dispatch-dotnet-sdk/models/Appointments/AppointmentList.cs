using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class AppointmentList : ListRoot {

    [JsonProperty("appointments")]
    public IEnumerable<Appointment> Appointments { get; set; }
  }

}
