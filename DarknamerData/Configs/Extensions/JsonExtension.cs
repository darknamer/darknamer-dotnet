using Newtonsoft.Json;

namespace Darknamer.Data.Configs.Extensions;

public static class JsonExtension
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    
    public static T? ToObject<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}