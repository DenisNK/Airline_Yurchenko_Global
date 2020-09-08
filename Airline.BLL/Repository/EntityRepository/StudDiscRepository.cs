using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
  public class StudDiscRepository : Repository<StudDisc>, IStudDiscRepository
    {
        public StudDiscRepository(DbContext context) : base(context) { }

        public IQueryable<StudDisc> GetAllStudDisc()
        {
            return _dbSet
                .Include(o => o.Discipline)
                .Include(o => o.Student)
                .AsNoTracking();
        }

        public Task<StudDisc> MyStudUnique(Expression<Func<StudDisc, bool>> predicate)
        {
            return _context.Set<StudDisc>().FirstOrDefaultAsync(predicate);
        }
    }
}
