using League.Domain.Interface;
using League.Model.Champions;

namespace League.Domain.Service;

public class ChampionsService : IChampionsService
{
    public Task<IEnumerable<Champion>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Champion> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
