using League.Common;
using League.Common.Configuration;
using League.Common.Helpers;
using League.Model;
using League.Service.Interface;
using League.Service.Interface.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace League.Service;

public class RiotChampionsService : ApiServiceBase, IRiotChampionsService
{
    private readonly ChampionsConfiguration _configuration;
    private readonly string _championsTestFileName = "..\\League.Api\\Response\\champions.json";

    public RiotChampionsService(
        ILogger<ApiServiceBase> logger,
        IHttpClientFactory httpClientFactory,
        IOptions<ApiConfiguration> options)
        : base(logger, httpClientFactory, options.Value.Champions)
    {
        _configuration = options.Value.Champions;
    }

    public async Task<IEnumerable<ChampionDto>> GetAll()
    {
        var url = _configuration.GetAllChampionsUrl();
        IEnumerable<ChampionDto> result;

        var response = await GetObjectFromEndpoint<ChampionResponseDto>(url);
        if (response is not null)
        {
            result = response.Data.Values;
            return result;
        }
        var reposnseLocal = GetLocalChampsReponse();
        var deserialized = JsonSerializer.Deserialize<ChampionResponseDto>(reposnseLocal, LeagueJsonSerializerOptions.DefaultReadOptions);
        result = deserialized!.Data.Values;
        return result;
    }

    private string GetLocalChampsReponse()
    {
        using StreamReader r = new StreamReader(_championsTestFileName);
        string json = r.ReadToEnd();
        return json;
    }
}
