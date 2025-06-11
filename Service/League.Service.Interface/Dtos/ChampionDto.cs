using League.Service.Dtos;
using System.Text.Json.Serialization;

namespace League.Service.Interface.Dtos;

[Serializable]
public class ChampionDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("key")]
    public int Key { get; set; } 
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    [JsonPropertyName("blurb")]
    public string Blurb { get; set; } = string.Empty;
    [JsonPropertyName("info")]
    public InfoDto Info { get; set; } = new();
    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags = [];
    [JsonPropertyName("partype")]
    public string ParType { get; set; } = string.Empty;
    [JsonPropertyName("stats")]
    public StatDto Stats { get; set; } = new();
}
