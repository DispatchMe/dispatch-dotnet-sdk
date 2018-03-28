using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class UserList : ListRoot {

    [JsonProperty("users")]
    public IEnumerable<User> Users { get; set; }
  }

}
