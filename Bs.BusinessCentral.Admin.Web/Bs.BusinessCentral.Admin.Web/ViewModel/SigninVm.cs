using System.ComponentModel.DataAnnotations;

namespace Bs.BusinessCentral.Admin.Web.ViewModel;

/// <summary>
/// Sign in view model
/// </summary>
public class SigninVm
{
    [Required(ErrorMessage = "Mobile number or email required")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Password required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}