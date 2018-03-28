using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class SurveyResponse : ModelBase
  {
    [JsonProperty("rating")]
    public int Rating { get; set; }

    [JsonProperty("job_id")]
    public int JobId { get; set; }

    [JsonProperty("appointment_id")]
    public int AppointmentId { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
  }
}
