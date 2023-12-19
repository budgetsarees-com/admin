using Bs.BusinessCentral.Admin.Web.ViewModel;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using Bs.BusinessCentral.Admin.Web.Services.SessionService;

namespace Bs.BusinessCentral.Admin.Web.Services.AccountService;

public class AccountSrv : IAccountSrv
{
    /// <summary>
    /// Http client
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Token service
    /// </summary>
    private readonly ISessionSrv _sessionService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="sessionService"></param>
    public AccountSrv(HttpClient httpClient, ISessionSrv sessionService)
    {
        _httpClient = httpClient;
        _sessionService = sessionService;
    }

    /// <summary>
    /// Signin
    /// </summary>
    /// <param name="signinVm"></param>
    /// <returns></returns>
    /// <exception cref="BusinessException"></exception>
    public async Task Signin(SigninVm signinVm)
    {
        var response = await _httpClient.PostAsJsonAsync("bc/account/signin", signinVm);
        var responseData = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            await _sessionService.SigninAsync(responseData);
        }
        else if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.BadRequest)
        {
            BusinessException businessException = JsonConvert.DeserializeObject<BusinessException>(responseData)!;
            throw businessException!;
        }
    }
}