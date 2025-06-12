using League.Model.Champions;

namespace League.Domain.Interface;

public interface IChampionsService
{
    Task<IEnumerable<Champion>> GetAll();
    Task<Champion> GetById(int id);
}
