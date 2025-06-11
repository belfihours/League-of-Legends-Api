
namespace League.Common.Configuration;

public class ChampionsConfiguration : IEndpointConfiguration
{
    private const string _allChampionsEndpoint = "AllChampions";

    public string BaseUrl { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public Dictionary<string, string> Requests { get; set; } = []; 

    public string GetAllChampionsUrl()
    {
        if (string.IsNullOrEmpty(BaseUrl) || string.IsNullOrEmpty(Version))
        {
            throw new InvalidOperationException("BaseUrl and Version must be set before getting the endpoint.");
        }
        return $"{BaseUrl}/{Version}/{GetAllChampionsEndpoint()}";
    }

    public string GetAllChampionsUrl(string version)
    {
        if (string.IsNullOrEmpty(BaseUrl) || string.IsNullOrEmpty(Version))
        {
            throw new InvalidOperationException("BaseUrl and Version must be set before getting the endpoint.");
        }
        return $"{BaseUrl}/{version}/{GetAllChampionsEndpoint()}";
    }

    private string GetAllChampionsEndpoint()
    {
        return Requests.GetValueOrDefault(_allChampionsEndpoint)
               ?? throw new KeyNotFoundException($"Endpoint '{_allChampionsEndpoint}' not found in Requests dictionary.");
    }
}
