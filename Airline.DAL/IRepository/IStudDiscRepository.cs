using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository
{
    public interface IStudDiscRepository : IGenericRepository<StudDisc>
    {
        Task<StudDisc> MyStudUnique(Expression<Func<StudDisc, bool>> predicate);
        IQueryable<StudDisc> GetAllStudDisc();
    }
}
