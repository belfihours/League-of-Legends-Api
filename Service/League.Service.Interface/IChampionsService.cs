using League.Service.Interface.Dtos;

namespace League.Service.Interface;

public interface IChampionsService
{
    Task<IEnumerable<ChampionDto>> GetAll();
    Task<ChampionDto> GetById(string id);
}
