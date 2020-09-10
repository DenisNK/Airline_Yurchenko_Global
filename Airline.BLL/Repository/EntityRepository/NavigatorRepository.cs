using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Airline.BLL.Repository.EntityRepository
{
    class NavigatorRepository : Repository<Navigator>, INavigatorRepository
    {
        public NavigatorRepository(DbContext context) : base(context)
        {
        }
        public async Task<Navigator> GetNavigationByIdWithTeamAsync(int? id)
        {
            return await Task.Run(() => GetNavigationByIdWithTeam(id));
        }

        private Navigator GetNavigationByIdWithTeam(int? id)
        {
            return _dbSet
                .Include(o => o.Team_Person)
                .AsNoTracking()
                .SingleOrDefault(o => o.Id == id);
        }

    
        public Task<Navigator> MyDiscUnique(Expression<Func<Navigator, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}