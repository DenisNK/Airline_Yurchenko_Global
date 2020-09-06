using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.IRepository;
using Global_Logic_ASP.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Global_Logic_ASP.Core.Repository
{
    public class DisciplinesRepository : Repository<Discipline>, IDisciplinesRepository
    {
        public DisciplinesRepository(DbContext context) : base(context) { }

        public Task<Discipline> MyDiscUnique(Expression<Func<Discipline, bool>> predicate)
        {
            return _context.Set<Discipline>().FirstOrDefaultAsync(predicate);
        }

        private Discipline GetDiscWithTeacherById(int? id)
        {
            return _dbSet
                .Include(o => o.Teacher)
                .AsNoTracking()
                .SingleOrDefault(o => o.Id == id);
        }

        public async Task<Discipline> GetDiscByIdWithTeacherAsync(int? id)
        {
            return await Task.Run(() => GetDiscWithTeacherById(id));
        }

    }
}
