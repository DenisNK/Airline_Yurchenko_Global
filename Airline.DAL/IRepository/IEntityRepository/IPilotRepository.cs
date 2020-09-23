using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
   public interface IPilotRepository : IGenericRepository<Pilot>
    {

        Task<Pilot> MyDiscUnique(Expression<Func<Pilot, bool>> predicate);
        Task<Pilot> GetPilotcByIdWithTeamAsync(int? id);
        Task CreateWithImage(Pilot entity);
        IQueryable<Pilot> GetAllPilot();
        Task GetByIdWithImage(int id, Pilot entity);
    }
}
