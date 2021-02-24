using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    public class UserRepository : Repository<UserProfile>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public Task<UserProfile> MyStudUnique(Expression<Func<UserProfile, bool>> predicate)
        {
            return _context.Set<UserProfile>().FirstOrDefaultAsync(predicate);
        }
    }
}
