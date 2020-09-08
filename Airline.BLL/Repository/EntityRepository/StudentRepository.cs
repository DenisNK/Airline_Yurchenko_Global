using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context) { }

        public Task<Student> MyStudUnique(Expression<Func<Student, bool>> predicate)
        {
            return _context.Set<Student>().FirstOrDefaultAsync(predicate);
        }
    }
}
