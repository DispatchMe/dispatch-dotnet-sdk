using System;
using Newtonsoft.Json;

namespace Dispatch.Models
{
  public abstract class ModelBase
  {
      [JsonProperty("id")]
      public int Id { get; set; }

      [JsonProperty("updated_at")]
      public DateTime UpdateAt { get; set; }

      [JsonProperty("created_at")]
      public DateTime CreatedAt { get; }
  }
}
