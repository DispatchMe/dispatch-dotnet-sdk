using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class Appointment : ModelBase
  {
    [JsonProperty("job_id")]
    public int JobId { get; set; }

    [JsonProperty("organization_id")]
    public int OrganizationId { get; set; }

    [JsonProperty("time")]
    public DateTime Time { get; set; }

    [JsonProperty("duration")]
    public int? Duration { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
  }
}
