using Newtonsoft.Json;

namespace Bs.BusinessCentral.Admin.Web.Helpers;

/// <summary>
/// Json helper
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// Convert string to model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="JsonException"></exception>
    public static async Task<T> ConvertToModel<T>(this HttpResponseMessage input)
    {
        var content = await input.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<T>(content)!;
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Error deserializing content to type {typeof(T).Name}. Content: {content}", ex);
        }
    }

    /// <summary>
    /// Convert model to json
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ConvertToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}
