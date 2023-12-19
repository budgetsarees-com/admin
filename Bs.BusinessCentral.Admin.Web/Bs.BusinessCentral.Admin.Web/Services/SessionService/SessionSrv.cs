using Blazored.LocalStorage;

namespace Bs.BusinessCentral.Admin.Web.Services.SessionService;

/// <summary>
/// Session service
/// </summary>
public class SessionSrv : ISessionSrv
{

    /// <summary>
    /// Local storage service
    /// </summary>
    private readonly ILocalStorageService _localStorageService;

    /// <summary>
    /// Token service
    /// </summary>
    private readonly ITokenSrv _tokenService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="localStorageService"></param>
    /// <param name="tokenService"></param>
    public SessionSrv(ILocalStorageService localStorageService, ITokenSrv tokenService)
    {
        _localStorageService = localStorageService;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Signin user
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SigninAsync(string token)
    {
        await _tokenService.SetAccessTokenAsync(token);
    }

    /// <summary>
    /// Signout user
    /// </summary>
    /// <returns></returns>
    public async Task SignoutAsync()
    {
        await _localStorageService.ClearAsync();
    }
}