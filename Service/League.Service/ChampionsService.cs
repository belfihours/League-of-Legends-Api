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

public class ChampionsService : ApiServiceBase, IChampionsService
{
    private readonly ChampionsConfiguration _configuration;
    private readonly string _championsTestFileName = "..\\League.Api\\Response\\champions.json";

    public ChampionsService(
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

        //var response = GetObjectFromEndpoint<IEnumerable<Champion>>(url);
        //var responseLocal = "\\""\\""
        var reposnseLocal = GetLocalChampsReponse();
        var result = JsonSerializer.Deserialize<ChampionResponseDto>(reposnseLocal, LeagueJsonSerializerOptions.DefaultReadOptions);

        return result!.Data.Select(data => data.Value);
    }

    private string GetLocalChampsReponse()
    {
        using StreamReader r = new StreamReader(_championsTestFileName);
        string json = r.ReadToEnd();
        return json;
    }

    public Task<ChampionDto> GetById(string id)
    {
        throw new NotImplementedException();
    }
}
