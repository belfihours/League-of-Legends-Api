using League.Common.Configuration;
using League.Service.IntegrationTest.Tools;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using WireMock.Server;

namespace League.Service.IntegrationTest;

public class RiotChampionsServiceTest : IClassFixture<WireMockFixture>
{
    private const string _getAllChampionsResponsePath = "TestData\\champions-response.json";

    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new();
    private readonly Mock<IOptions<ApiConfiguration>> _optionsMock = new();
    private readonly Mock<ILogger<RiotChampionsService>> _loggerMock = new();
    private readonly WireMockServer _wireMockServer;

    public RiotChampionsServiceTest(WireMockFixture wireMockFixture)
    {
        _wireMockServer = wireMockFixture.WiremockServer;
    }

    [Fact]
    public void WhenFetchingAllChampions_ThenReturnsChampionsDto()
    {
        var apiConfiguration = GivenConfigurationForEndpoint(_wireMockServer.Port, "data/en_US/champion.json");

    }

    private static ApiConfiguration GivenConfigurationForEndpoint(int port, string endpoint)
    {
        var apiConfigurations = new ApiConfiguration
        {
            Champions = new ChampionsConfiguration
            {
                BaseUrl = $"http://localhost:{port}",
                Version = "15.12.1",
                Requests = new()
                {
                    {
                        ChampionsConfiguration.AllChampionsEndpoint, endpoint
                    }
                }
            }
        };
        return apiConfigurations;
    }
}