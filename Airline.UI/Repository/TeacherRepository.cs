using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.IRepository;
using Global_Logic_ASP.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Global_Logic_ASP.Core.Repository
{

    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context) { }
        public IQueryable<Teacher> GetAllOrderedByName()
        {
            return _dbSet
                .OrderBy(c => c.Name)
                .AsNoTracking();
        }
        public SelectList SelectListTeacherName()
        {
            var a = _dbSet
                .OrderBy(c => c.Name)
                .AsNoTracking();

            return new SelectList(a, "Id", "Name");
        }

        public SelectList SelectListTeacherName(int? defaultItemId)
        {
            return new SelectList(_dbSet.OrderBy(c => c.Name)
                .AsNoTracking(), "Id", "Name", defaultItemId);
        }
    }
}
