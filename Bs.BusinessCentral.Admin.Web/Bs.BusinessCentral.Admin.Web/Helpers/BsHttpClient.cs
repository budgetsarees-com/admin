using System.Net.Http.Headers;
using Bs.BusinessCentral.Admin.Web.Services.SessionService;

namespace Bs.BusinessCentral.Admin.Web.Helpers;

public class BsHttpClient : HttpClient
{

    /// <summary>
    /// Http client 
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="tokenService"></param>
    public BsHttpClient(HttpClient httpClient, ITokenSrv tokenService)
    {
        _httpClient = httpClient;
        //try
        //{
        //    var r1 = tokenService.GetAccessTokenAsync().GetAwaiter().GetResult();
        //    var r = Task.Run(() => tokenService.GetAccessTokenAsync()).Result;
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenService.GetAccessTokenAsync().Result);
        //}
        //catch (Exception ex)
        //{
        //    var e = ex.Message;
        //}
    }
}