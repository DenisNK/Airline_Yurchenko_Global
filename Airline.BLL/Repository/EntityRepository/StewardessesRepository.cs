using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    class StewardessesRepository : Repository<Stewardess>, IStewardessesRepository
    {
        public StewardessesRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Stewardess> GetAllStewardess()
        {
            return _dbSet
                .Include(t => t.Team_Person)
                .AsNoTracking();
        }
        public async Task CreateWithImage(Stewardess entity)
        {
            await Task.Run(() =>
            {
                entity.ProfilePicture = UploadedFile(entity.ProfileImage);
                return Create(entity);
            });
        }
        public async Task GetByIdWithImage(int id, Stewardess entity)
        {
            await Task.Run(() =>
            {
                entity.ProfilePicture = UploadedFile(entity.ProfileImage);
                return Update(id, entity);
            });
        }
        public async Task<Stewardess> GetStewardessByIdWithTeamAsync(int? id)
        {
            return await Task.Run(() => GetStewardessByIdWithTeam(id));
        }
        private Stewardess GetStewardessByIdWithTeam(int? id)
        {
            return _dbSet
                .Include(o => o.Team_Person)
                .AsNoTracking()
                .SingleOrDefault(o => o.Id == id);
        }
    }
}