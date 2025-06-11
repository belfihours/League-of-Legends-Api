using League.Model;
using League.Service.Interface;
using League.Service.Interface.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace League.Api.Controllers;

[ApiController]
[Route("champion")]
public class ChampionsController : Controller
{

    [HttpGet("get-all", Name = "GetAllChampions")]
    public async Task<ActionResult<IEnumerable<ChampionDto>>> GetAll([FromServices] IChampionsService championsService)
    {
        var champions = await championsService.GetAll();
        return Ok(champions);
    }
}
