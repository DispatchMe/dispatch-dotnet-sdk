using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class Job : ModelBase
  {
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("service_type")]
    public string ServiceType { get; set; }

    [JsonProperty("external_ids")]
    public IList<string> ExternalIds { get; set; }

    [JsonProperty("address")]
    public Location Address { get; set; }

    [JsonProperty("brand_id")]
    public int? BrandId { get; set; }

    [JsonProperty("source_id")]
    public int SourceId { get; set; }

    [JsonProperty("customer_id")]
    public int CustomerId { get; set; }

    [JsonProperty("contacts")]
    public IList<Contact> Contacts { get; set; }

    [JsonProperty("organization_id")]
    public int OrganizationId { get; set; }

    [JsonProperty("service_fee")]
    public float ServiceFee { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("status_message")]
    public string StatusMessage { get; set; }
  }
}
