using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Airline.DAL.IRepository
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        IQueryable<Teacher> GetAllOrderedByName();
        SelectList SelectListTeacherName();
        SelectList SelectListTeacherName(int? defaultItemId);
    }
}
