namespace Bs.BusinessCentral.Admin.Web.Services.SessionService;

/// <summary>
/// Token service interface
/// </summary>
public interface ITokenSrv
{
    Task SetAccessTokenAsync(string token);

    Task<string> GetAccessTokenAsync();
}