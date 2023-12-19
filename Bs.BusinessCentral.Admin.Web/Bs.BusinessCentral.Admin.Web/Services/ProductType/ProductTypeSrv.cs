using Bs.BusinessCentral.Admin.Web.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net;
using Bs.BusinessCentral.Admin.Web.Services.SessionService;
using Bs.BusinessCentral.Admin.Web.Helpers;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Bs.BusinessCentral.Admin.Web.Services.ProductType;

/// <summary>
/// Product type master service
/// </summary>
public class ProductTypeSrv : IProductTypeSrv
{

    /// <summary>
    /// Http client
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Token service
    /// </summary>
    private readonly ITokenSrv _tokenService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpClient"></param>
    public ProductTypeSrv(HttpClient httpClient, ITokenSrv tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Delete product type
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"masters/product/type?id={id}");
        if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.BadRequest)
        {
            var businessError = JsonConvert.DeserializeObject<BusinessException>(await response.Content.ReadAsStringAsync());
            throw businessError!;
        }
    }

    /// <summary>
    /// Get product type by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ProductTypeVm> GetAsync(int id)
    {
        var response = await _httpClient.GetAsync($"masters/product/type?id={id}");
        var responseData = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<ProductTypeVm>(responseData)!;
        }
        else if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.BadRequest)
        {
            BusinessException businessException = JsonConvert.DeserializeObject<BusinessException>(responseData)!;
            throw businessException!;
        }

        return await Task.FromResult(default(ProductTypeVm)!);
    }

    /// <summary>
    /// Get all product type
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<ProductTypeVm>> GetAsync()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _tokenService.GetAccessTokenAsync());
        var response = await _httpClient.GetAsync("masters/product/type/all");
        var responseData = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<List<ProductTypeVm>>(responseData)!;
        }
        else if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.BadRequest)
        {
            BusinessException businessException = JsonConvert.DeserializeObject<BusinessException>(responseData)!;
            throw businessException!;
        }

        return await Task.FromResult(default(List<ProductTypeVm>)!);
    }

    /// <summary>
    /// Save product type
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task SaveAsync(ProductTypeVm entity)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _tokenService.GetAccessTokenAsync());
        var response = await _httpClient.PostAsJsonAsync("masters/product/type", entity);
        if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.BadRequest)
        {
            var businessError = JsonConvert.DeserializeObject<BusinessException>(await response.Content.ReadAsStringAsync());
            throw businessError!;
        }
    }

    /// <summary>
    /// Update product type
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateAsync(ProductTypeVm entity)
    {
        var response = await _httpClient.PutAsJsonAsync("masters/product/type", entity);
        if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.BadRequest)
        {
            var businessError = JsonConvert.DeserializeObject<BusinessException>(await response.Content.ReadAsStringAsync());
            throw businessError!;
        }
    }
}