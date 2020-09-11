using System;
using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    class TeamPersonRepository : Repository<Team_Person>, ITeamPersonRepository
    {
        public TeamPersonRepository(DbContext context) : base(context)
        {
        }

        public async Task<Team_Person> GetTeamByIdWithAllTeamAsync(int? id)
        {
            return await Task.Run(() => GetTeamByIdWithAllTeam(id));
        }
        private Team_Person GetTeamByIdWithAllTeam(int? id)
        {
            return _dbSet
                .Include(n => n.Navigators)
                .Include(p => p.Pilots)
                .Include(r => r.Radio_Operators)
                .Include(s => s.Stewardesses)
                .AsNoTracking()
                .SingleOrDefault(o => o.Id == id);
        }

        public SelectList SelectListTeamName()
        {
            var a = _dbSet
                .OrderBy(c => c.Name_Team)
                .AsNoTracking();

            return new SelectList(a, "Id", "Name_Team");
        }

        public SelectList SelectListTeamName(int? selectId)
        {
            return new SelectList(_dbSet.OrderBy(c => c.Name_Team)
                .AsNoTracking(), "Id", "Name_Team", selectId);
        }
    }
}