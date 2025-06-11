namespace League.Common.Configuration;

public interface IEndpointConfiguration
{
    string BaseUrl { get; set; }
    string Version { get; set; }
    Dictionary<string, string> Requests { get; }
}
