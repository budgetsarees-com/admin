using Bs.BusinessCentral.Admin.Web.Services.SessionService;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bs.BusinessCentral.Admin.Web;

public class BsStateProvider : AuthenticationStateProvider
{
    /// <summary>
    /// Token service
    /// </summary>
    private readonly ITokenSrv _tokenService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tokenService"></param>
    public BsStateProvider(ITokenSrv tokenService)
    {
        _tokenService = tokenService;
    }

    /// <summary>
    /// Get authentication state
    /// </summary>
    /// <returns></returns>
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var SavedToken = await _tokenService.GetAccessTokenAsync();

        if (string.IsNullOrEmpty(SavedToken))
        {
            // No access token, user is not authenticated
            var anonymousIdentity = new ClaimsIdentity();
            var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
            return new AuthenticationState(anonymousPrincipal);
        }

        var jwtSecurityToken = tokenHandler.ReadJwtToken(SavedToken);
        var identity = new ClaimsIdentity(jwtSecurityToken!.Claims, "BudgetSarees.com");
        var principal = new ClaimsPrincipal(identity);
        var authenticationState = new AuthenticationState(principal);

        NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));

        return authenticationState;
    }

    /// <summary>
    /// Check if user is authenticated
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsUserAuthenticated()
    {
        var authState = await GetAuthenticationStateAsync();

        if (authState.User.Identity!.IsAuthenticated)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Get user label name
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetUserLabelName()
    {
        var authState = await GetAuthenticationStateAsync();
        Claim subjectClaim = authState.User.FindFirst("first_name")!;
        if (subjectClaim != null)
            return subjectClaim.Value;
        else
            return string.Empty;
    }
}