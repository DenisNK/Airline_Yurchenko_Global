using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Global_Logic_ASP.Core.IRepository
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        IQueryable<Teacher> GetAllOrderedByName();
        SelectList SelectListTeacherName();
        SelectList SelectListTeacherName(int? defaultItemId);
    }
}
