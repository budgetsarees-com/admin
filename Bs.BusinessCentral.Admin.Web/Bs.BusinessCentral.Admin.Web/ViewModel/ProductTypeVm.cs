using System.ComponentModel.DataAnnotations;

namespace Bs.BusinessCentral.Admin.Web.ViewModel;

/// <summary>
/// Product type view model
/// </summary>
public class ProductTypeVm
{
    public string Id { get; set; } = null!;

    [Required(ErrorMessage = "required")]
    public string NameEn { get; set; } = null!;

    public string LastUpdatedOn { get; set; } = null!;
}