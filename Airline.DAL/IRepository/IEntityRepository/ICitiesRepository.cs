using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface ICitiesRepository : IGenericRepository<City>
    {
        SelectList SelectListCity();
        SelectList SelectListCity(int? selectId);

    }
}
