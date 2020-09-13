using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    class PilotRepository : Repository<Pilot>, IPilotRepository
    {
        //  private readonly IWebHostEnvironment _webHostEnvironment;   ??

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

        private Pilot GetPilotcByIdWithTeam(int? id)
        {
            return _dbSet
                .Include(o => o.Team_Person)
                .AsNoTracking()
                .SingleOrDefault(o => o.Id == id);
        }

        public async Task CreateWithImage(Pilot entity)
        {
            await Task.Run(() =>
            {
                entity.ProfilePicture = UploadedFile(entity.ProfileImage);
                return Create(entity);
            });
        }
                   
        public IQueryable<Pilot> GetAllPilot()
        {
            return _dbSet
                .Include(t => t.Team_Person)
                .AsNoTracking();
        }

        public async Task GetByIdWithImage(int id, Pilot entity)
        {
            await Task.Run(() =>
            {
                entity.ProfilePicture = UploadedFile(entity.ProfileImage);
                return Update(id, entity);
            });
        }
    }
}