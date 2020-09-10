using System.Linq;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        IQueryable<Teacher> GetAllOrderedByName();
        SelectList SelectListTeacherName();
        SelectList SelectListTeacherName(int? selectId);
    }
}
