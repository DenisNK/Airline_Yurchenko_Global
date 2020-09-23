using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface IStewardessesRepository:IGenericRepository<Stewardess>
    {
        IQueryable<Stewardess> GetAllStewardess();
        Task<Stewardess> GetStewardessByIdWithTeamAsync(int? id);
        Task CreateWithImage(Stewardess entity);
        Task GetByIdWithImage(int id, Stewardess entity);

    }
}
