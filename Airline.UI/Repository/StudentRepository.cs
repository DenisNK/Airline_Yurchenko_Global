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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context) { }

        public Task<Student> MyStudUnique(Expression<Func<Student, bool>> predicate)
        {
            return _context.Set<Student>().FirstOrDefaultAsync(predicate);
        }
    }
}
