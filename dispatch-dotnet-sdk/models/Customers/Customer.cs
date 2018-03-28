using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class Customer : ModelBase {

    [JsonProperty("organization_id")]
    public int OrganizationId { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("company_name")]
    public string CompanyName { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("phone_numbers")]
    public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
  }

}
