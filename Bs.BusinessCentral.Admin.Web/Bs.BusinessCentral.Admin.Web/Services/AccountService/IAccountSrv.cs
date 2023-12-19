using Bs.BusinessCentral.Admin.Web.ViewModel;

namespace Bs.BusinessCentral.Admin.Web.Services.AccountService;

/// <summary>
/// Account service interface
/// </summary>
public interface IAccountSrv
{
    Task Signin(SigninVm signinVm);
}
