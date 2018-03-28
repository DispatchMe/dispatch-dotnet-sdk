using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class CustomerList : ListRoot {

    [JsonProperty("customers")]
    public IEnumerable<Customer> Customers { get; set; }
  }

}
