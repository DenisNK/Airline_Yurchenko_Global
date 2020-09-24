using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface IRequsetRepository : IGenericRepository<Request>
    {
        IQueryable<Request> GetListProblem(string id);
        Task<Request> GetRequestByIdAsync(int? id);
        Task RemoveRequest(Request request);
    }
}
