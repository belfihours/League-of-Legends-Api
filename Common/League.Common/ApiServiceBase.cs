using League.Common.Configuration;
using League.Common.Helpers;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text.Json;

namespace League.Common;

public class ApiServiceBase
{
    private ILogger<ApiServiceBase> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IEndpointConfiguration _endpointConfiguration;

    protected HttpClient HttpClient { get; private set; }

    protected const string _mediaTypeJson = "application/json";

    public ApiServiceBase(
        ILogger<ApiServiceBase> logger,
        IHttpClientFactory httpClientFactory,
        IEndpointConfiguration endpointConfiguration)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _endpointConfiguration = endpointConfiguration ?? throw new ArgumentNullException(nameof(endpointConfiguration));
    }

    public async Task<T> GetObjectFromEndpoint<T>(string endpointUrl)
    {
        ArgumentNullException.ThrowIfNull(endpointUrl);

        SetupRequest();
        var response = await HttpClient.GetAsync(endpointUrl);

        if(response.IsSuccessStatusCode)
        {
            var jsonResult = await response.Content.ReadAsStringAsync();
            var responseItem = JsonSerializer.Deserialize<T>(jsonResult, LeagueJsonSerializerOptions.DefaultReadOptions);
            ArgumentNullException.ThrowIfNull(responseItem, $"Deserialized object of type {typeof(T)} is null. Check the endpoint response and serialization settings.");

            _logger.LogInformation("Successfully retrieved \"{type}\", from endpoint: \"{endpoint}\".", typeof(T), endpointUrl);
            return responseItem;
        }

        var serviceError = await response.Content.ReadAsStringAsync();
        _logger.LogError("Failed to get object from endpoint {Url}. Status code: {StatusCode}, Error: {ServiceError}",
            endpointUrl,
            response.StatusCode,
            serviceError);
        throw new HttpRequestException($"Request to {endpointUrl} failed with status code {response.StatusCode} and error: {serviceError}");
    } 

    public void SetupRequest()
    {
        SetupClient();

        // Potential token setup here
    }

    private void SetupClient()
    {
        HttpClient = _httpClientFactory.CreateClient(GetType().Name);
        HttpClient.BaseAddress = new Uri(_endpointConfiguration.BaseUrl);
    }
}
