using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class BearerResponse {

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get { return "bearer" ;} }

    [JsonProperty("created_at")]
    public long CreatedAt { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set;}

    [JsonProperty("error")]
    public string Error { get; set; }

    [JsonProperty("error_description")]
    public string ErrorDescription { get; set; }

    [JsonIgnore] //Convenience property
    public bool HasError { get { return ! string.IsNullOrWhiteSpace(Error); } }
  }
}
