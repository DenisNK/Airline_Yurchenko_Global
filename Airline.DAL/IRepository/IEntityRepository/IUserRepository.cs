using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface IUserRepository : IGenericRepository<UserProfile>
    {
        Task<UserProfile> MyStudUnique(Expression<Func<UserProfile, bool>> predicate);
    }
}
