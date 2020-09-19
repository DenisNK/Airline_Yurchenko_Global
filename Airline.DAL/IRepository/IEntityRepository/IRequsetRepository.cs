using System.Linq;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface IRequsetRepository : IGenericRepository<Request>
    {
        IQueryable<Request> GetListProblem(string id);
    }
}
