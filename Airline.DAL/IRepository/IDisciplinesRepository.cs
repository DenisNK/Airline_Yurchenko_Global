using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository
{
    public interface IDisciplinesRepository : IGenericRepository<Discipline>
    {
        Task<Discipline> MyDiscUnique(Expression<Func<Discipline, bool>> predicate);
        Task<Discipline> GetDiscByIdWithTeacherAsync(int? id);

    }

}
