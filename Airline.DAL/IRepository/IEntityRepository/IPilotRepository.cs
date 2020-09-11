using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.DAL.IRepository.IEntityRepository
{
   public interface IPilotRepository : IGenericRepository<Pilot>
    {
        Task<Pilot> MyDiscUnique(Expression<Func<Pilot, bool>> predicate);
        Task<Pilot> GetPilotcByIdWithTeamAsync(int? id);

      
    }
}
