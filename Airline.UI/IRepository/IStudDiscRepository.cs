using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.Models;

namespace Global_Logic_ASP.Core.IRepository
{
  public interface IStudDiscRepository : IGenericRepository<StudDisc>
    {
        Task<StudDisc> MyStudUnique(Expression<Func<StudDisc, bool>> predicate);
        IQueryable<StudDisc> GetAllStudDisc();
    }
}
