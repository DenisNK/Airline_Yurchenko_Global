using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface INavigatorRepository : IGenericRepository<Navigator>
    {
        Task<Navigator> MyDiscUnique(Expression<Func<Navigator, bool>> predicate);
        Task<Navigator> GetNavigationByIdWithTeamAsync(int? id);

    }
}
