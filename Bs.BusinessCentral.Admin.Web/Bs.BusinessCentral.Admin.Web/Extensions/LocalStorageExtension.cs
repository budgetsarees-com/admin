using Blazored.LocalStorage;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bs.BusinessCentral.Admin.Web;

/// <summary>
/// Local storage extension
/// </summary>
public static class LocalStorageExtension
{

    /// <summary>
    /// Register local storage extension
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterLocalStorage(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorageAsSingleton(config =>
        {
            config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
            config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
            config.JsonSerializerOptions.WriteIndented = false;
        });
    }
}