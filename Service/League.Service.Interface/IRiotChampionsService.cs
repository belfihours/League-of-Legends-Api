using League.Service.Interface.Dtos;

namespace League.Service.Interface;

public interface IRiotChampionsService
{
    Task<IEnumerable<ChampionDto>> GetAll();
}
