using System.Linq;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    class CitiesRepository : Repository<City>, ICitiesRepository
    {
        public CitiesRepository(DbContext context) : base(context)
        {
        }

        public SelectList SelectListCity()
        {
            var a = _dbSet
                .OrderBy(c => c.Name_City)
                .AsNoTracking();

            return new SelectList(a, "Id", "Name_City");
        }

        public SelectList SelectListCity(int? selectId)
        {
            return new SelectList(_dbSet.OrderBy(c => c.Name_City)
                .AsNoTracking(), "Id", "Name_City", selectId);
        }
    }
}
