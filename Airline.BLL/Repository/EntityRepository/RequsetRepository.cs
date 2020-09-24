using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    class RequsetRepository : Repository<Request>, IRequsetRepository
    {
        public RequsetRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Request> GetListProblem(string id)
        {
            return _dbSet.Where(sign => sign.SignIn == id);
        }
        private Request GetRequestById(int? id)
        {
            return _dbSet.SingleOrDefault(e => e.RequestRef == id);
        }
        public async Task<Request> GetRequestByIdAsync(int? id)
        {
            return await Task.Run(() => GetRequestById(id));
        }
        public async Task RemoveRequest(Request request)
        {
            _context.Set<Request>().Remove(request);
            await _context.SaveChangesAsync();
        }

    }
}
