using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dispatch.Models;
using Newtonsoft.Json;
using System.Linq;

namespace Dispatch
{
  /// <summary>
  /// Client is the root object for connecting to
  /// the Dispatch API
  /// </summary>
  public class Client : IDisposable, IBrandClient, ICustomerClient, IUserClient, ISurveyResponseClient, IJobClient, IAppointmentClient
  {
    private readonly HttpClient _client;
    private const string BASE_ADDRESS = "https://api-dev.dispatch.me/";
    public Client(string baseAddress = BASE_ADDRESS, string version = "v3")
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri($"{baseAddress}{version}/");
    }

    public async Task<BearerResponse> Authenticate(string clientID, string clientSecret)
    {
        var clientCredentials = new ClientCredentials {
            ClientID = clientID,
            ClientSecret = clientSecret
        };

        var response = await _client.PostJsonAsync("oauth/token", clientCredentials);
        var content = await response.Content.ReadAsStringAsync();
        var bearer = JsonConvert.DeserializeObject<BearerResponse>(content);

        if (! bearer.HasError) {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer.AccessToken);
        }

        return bearer;
    }

    #region Brands
    public async Task<BrandList> ListBrandsAsync()
    {
        return await ListAsync<BrandList, Brand>();
    }

    public async Task<BrandResult> UpdateBrandAsync(int id, Dictionary<string, object> data)
    {
        return await UpdateAsync<BrandResult, Brand>(id, data);
    }

    public async Task DeleteBrandAsync(int id)
    {
        await DeleteAsync<Brand>(id);
    }
    #endregion

    #region Customers
    public async Task<CustomerList> ListCustomersAsync()
    {
        return await ListAsync<CustomerList, Customer>();
    }
    #endregion

    #region Organizations
    public async Task<OrganizationList> ListOrganizationsAsync()
    {
        return await ListAsync<OrganizationList, Organization>();
    }
    #endregion

    #region Users
    public async Task<UserList> ListUsersAsync()
    {
        return await ListAsync<UserList, User>();
    }
    #endregion

    #region SurveyResponses
    public async Task<SurveyResponseList> ListSurveyResponsesAsync()
    {
        return await ListAsync<SurveyResponseList, SurveyResponse>();
    }
    #endregion

    #region Appointment
    public async Task<AppointmentList> ListAppointmentsAsync()
    {
        return await ListAsync<AppointmentList, Appointment>();
    }
    #endregion

    #region Job
    public async Task<JobList> ListJobsAsync()
    {
        return await ListAsync<JobList, Job>();
    }
    #endregion

    protected async Task<TList> ListAsync<TList, TModel>(string requestUri = null)
    {
        requestUri = requestUri ?? typeof(TModel).PluralizeAndExpandNameToLower();
        return await _client.GetJsonStringAsync<TList>(requestUri);
    }

    protected async Task DeleteAsync<TModel>(int id, string requestUri = null)
    {
        requestUri = requestUri ?? typeof(TModel).PluralizeAndExpandNameToLower();
        await _client.DeleteAsync($"{requestUri}/{id}");
    }

    protected async Task<TResult> UpdateAsync<TResult, TModel>(int id, Dictionary<string, object> data, string requestUri = null)
    {
        requestUri = requestUri ?? typeof(TModel).PluralizeAndExpandNameToLower();
        var response = await _client.PatchJsonAsync($"{requestUri}/{id}", data);
        return JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
    }

    public void Dispose() => throw new NotImplementedException();
  }
}
