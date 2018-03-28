using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace Dispatch {

  public static class HttpClientExtensions {

    private const string MEDIA_TYPE_JSON = "application/json";

    /// <summary>
    /// PostJsonAsync wraps extends HttpClient with JSON posting abilities
    /// </summary>
    /// <param name="client">The client to extend</param>
    /// <param name="requestUri">The request URI</param>
    /// <param name="data">The data to post</param>
    /// <returns>The HttpResponseMessage</returns>
    public static Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient client, string requestUri, T data) {
      var json = JsonConvert.SerializeObject(data);
      var content = new StringContent(json, Encoding.UTF8, MEDIA_TYPE_JSON);
      return client.PostAsync(requestUri, content);
    }

    /// <summary>
    /// GetJsonStringAsync extends HttpClient with get string as JSON abilities
    /// </summary>
    /// <param name="client">The client to extend</param>
    /// <param name="requestUri">The request URI</param>
    /// <returns>The response string as JSON</returns>
    public async static Task<T> GetJsonStringAsync<T>(this HttpClient client, string requestUri)  {
      Console.WriteLine(requestUri);

      var data = await client.GetStringAsync(requestUri);
      return JsonConvert.DeserializeObject<T>(data);
    }

    /// <summary>
    /// PatchJsonAsync wraps extends HttpClient with JSON patching abilities
    /// </summary>
    /// <param name="client">The client to extend</param>
    /// <param name="requestUri">The request URI</param>
    /// <param name="data">The data to post</param>
    /// <returns>The HttpResponseMessage</returns>
    public static Task<HttpResponseMessage> PatchJsonAsync<T>(this HttpClient client, string requestUri, T data) {
      var json = JsonConvert.SerializeObject(data);
      var content = new StringContent(json, Encoding.UTF8, MEDIA_TYPE_JSON);
      var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
      {
        Content = content
      };
      return client.SendAsync(request);
    }
  }
}
