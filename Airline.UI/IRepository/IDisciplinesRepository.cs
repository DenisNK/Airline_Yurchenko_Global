using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.Models;
using Global_Logic_ASP.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Global_Logic_ASP.Core.IRepository
{
    public interface IDisciplinesRepository : IGenericRepository<Discipline>
    {
        Task<Discipline> MyDiscUnique(Expression<Func<Discipline, bool>> predicate);
        Task<Discipline> GetDiscByIdWithTeacherAsync(int? id);

    }

}
