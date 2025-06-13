using WireMock.Server;

namespace League.Service.IntegrationTest.Tools;

public class WireMockFixture : IDisposable
{
    public WireMockServer WiremockServer { get; }

    public WireMockFixture()
    {
        WiremockServer = WireMockServer.Start();
    }

    public void Dispose()
    {
        WiremockServer.Dispose();
    }
}
