using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface IFligthRepository:IGenericRepository<Fligth>
    {
        IQueryable<Fligth> GetFligthAdminDisp();
        IQueryable<Fligth> GetFligthAllUsers();

    }
}
