using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models
{
  public class Contact
  {
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("primary")]
    public bool Primary { get; set; }

    [JsonProperty("relationship")]
    public string Relationship { get; set; }

    [JsonProperty("address")]
    public Location Address { get; set; }

    [JsonProperty("contact_methods")]
    public IList<ContactMethod> ContactMethods { get; set; }
  }
}
