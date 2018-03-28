using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class OrganizationList : ListRoot {

    [JsonProperty("organizations")]
    public IEnumerable<Organization> Organizations { get; set; }
  }

}
