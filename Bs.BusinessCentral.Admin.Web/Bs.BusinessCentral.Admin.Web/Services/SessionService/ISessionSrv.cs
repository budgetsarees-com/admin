namespace Bs.BusinessCentral.Admin.Web.Services.SessionService;

/// <summary>
/// Session service interface
/// </summary>
public interface ISessionSrv
{
    Task SigninAsync(string token);

    Task SignoutAsync();
}