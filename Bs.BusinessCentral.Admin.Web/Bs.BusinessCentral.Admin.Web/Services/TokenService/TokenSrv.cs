using Blazored.LocalStorage;

namespace Bs.BusinessCentral.Admin.Web.Services.SessionService;

/// <summary>
/// Session service
/// </summary>
public class TokenSrv : ITokenSrv
{

    /// <summary>
    /// Local storage service
    /// </summary>
    private readonly ILocalStorageService _localStorageService;

    /// <summary>
    /// Auth token label
    /// </summary>
    private readonly string _authTokenLabel;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="localStorageService"></param>
    public TokenSrv(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
        _authTokenLabel = "auth_token";
    }

    /// <summary>
    /// Get access token
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetAccessTokenAsync()
    {
        return await _localStorageService.GetItemAsync<string>(_authTokenLabel);
    }

    /// <summary>
    /// Set access token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task SetAccessTokenAsync(string token)
    {
        await _localStorageService.SetItemAsync(_authTokenLabel, token);
    }

    /// <summary>
    /// Signout
    /// </summary>
    /// <returns></returns>
    public async Task SignoutAsync()
    {
        await _localStorageService.ClearAsync();
    }
}