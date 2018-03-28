using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class JobList : ListRoot {

    [JsonProperty("jobs")]
    public IEnumerable<Job> Jobs { get; set; }
  }

}
