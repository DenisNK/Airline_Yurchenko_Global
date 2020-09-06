using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.IRepository;
using Global_Logic_ASP.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Global_Logic_ASP.Core.Repository
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
