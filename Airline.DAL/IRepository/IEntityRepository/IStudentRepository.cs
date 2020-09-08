using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> MyStudUnique(Expression<Func<Student, bool>> predicate);
    }
}
