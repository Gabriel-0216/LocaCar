using System.Text.Json;

namespace LocaCar.WebApp.Services;

public static class DeserializerSettings
{
    public static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
    }

}