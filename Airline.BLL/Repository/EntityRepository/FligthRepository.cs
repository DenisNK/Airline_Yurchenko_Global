using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    public class FligthRepository : Repository<Fligth>, IFligthRepository
    {
        public FligthRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Fligth> GetFligthAdmin()
        {
            return _dbSet.Include(f => f.FromCity).Include(f => f.WhereCity)
                    .Include(r => r.FromCity.Country).Include(t => t.WhereCity.Country).AsNoTracking();
        }

        public IQueryable<Fligth> GetFligthAdminDisp(string name)
        {
            
                return _dbSet.Include(f => f.FromCity).Include(f => f.WhereCity)
                    .Include(r => r.FromCity.Country).Include(t => t.WhereCity.Country).Include(req => req.Request)
                    .Where(r => r.Request.SignIn == name).AsNoTracking();
         
        }
        public IQueryable<Fligth> GetFligthAllUsers()
        {
            return _dbSet.Include(f => f.FromCity).Include(f => f.WhereCity)
                .Include(r => r.FromCity.Country).Include(t => t.WhereCity.Country).Where(confirm=>confirm.IsConfirmed).AsNoTracking();
        }

        public async Task<Fligth> GetFligthByIdAsync(int? id)
        {
            return await Task.Run(() => GetFligthById(id));

        }
        private Fligth GetFligthById(int? id)
        {
            return _dbSet
                .Include(f => f.FromCity)
                .Include(f => f.WhereCity)
                .Include(req => req.Request)
                .AsNoTracking()
                .FirstOrDefault(o=>o.Id == id);
        }
    }
}
