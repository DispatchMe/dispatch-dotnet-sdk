using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class JobResult : SingleRoot {

    [JsonProperty("job")]
    public Job Job { get; set; }
  }
}
