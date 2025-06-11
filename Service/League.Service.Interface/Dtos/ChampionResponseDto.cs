using System.Text.Json.Serialization;

namespace League.Service.Interface.Dtos;

[Serializable]
public class ChampionResponseDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    [JsonPropertyName("format")]
    public string Format { get; set; } = string.Empty;
    [JsonPropertyName("version")]
    public string Version { get; set; } = string.Empty;
    [JsonPropertyName("data")]
    public Dictionary<string, ChampionDto> Data { get; set; } = [];
}
