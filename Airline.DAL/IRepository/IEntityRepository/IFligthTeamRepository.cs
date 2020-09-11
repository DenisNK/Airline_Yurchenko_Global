using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface ITeamPersonRepository : IGenericRepository<Team_Person>
    {
        Task<Team_Person> GetTeamByIdWithAllTeamAsync(int? id);
        SelectList SelectListTeamName();
        SelectList SelectListTeamName(int? selectId);

    }
}
