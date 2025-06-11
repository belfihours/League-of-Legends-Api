using System.Text.Json;
using System.Text.Json.Serialization;

namespace League.Common.Helpers;

public static class LeagueJsonSerializerOptions
{
    public static readonly JsonSerializerOptions DefaultReadOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };
}
