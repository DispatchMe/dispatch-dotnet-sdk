using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  /// <summary>
  /// ClientCredentials represent the required fields for
  /// a client_credentials grant request
  /// </summary>
  public class ClientCredentials {

    [JsonProperty("grant_type")]
    public string GrantType { get { return "client_credentials" ; } }

    [JsonProperty("client_id")]
    public string ClientID { get; set; }

    [JsonProperty("client_secret")]
    public string ClientSecret { get; set; }
  }

}
