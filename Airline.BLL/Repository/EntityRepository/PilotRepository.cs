using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    class PilotRepository : Repository<Pilot>, IPilotRepository
    {
        public PilotRepository(DbContext context) : base(context)
        {
        }

        public async Task<Pilot> GetPilotcByIdWithTeamAsync(int? id)
        {
            return await Task.Run(() => GetPilotcByIdWithTeam(id));
        }

        public Task<Pilot> MyDiscUnique(Expression<Func<Pilot, bool>> predicate)
        {
            return _context.Set<Pilot>().FirstOrDefaultAsync(predicate);
        }

        public SelectList SelectListTeamName()
        {
            var a = _dbSet
                .OrderBy(c => c.Name)
                .AsNoTracking();

            return new SelectList(a, "Id", "Name");
        }

        public SelectList SelectListTeamName(int? selectId)
        {
            return new SelectList(_dbSet.OrderBy(c => c.Name)
                .AsNoTracking(), "Id", "Name", selectId);
        }

        private Pilot GetPilotcByIdWithTeam(int? id)
        {
            return _dbSet
                .Include(o => o.Team_Person)
                .AsNoTracking()
                .SingleOrDefault(o => o.Id == id);
        }
    }
}