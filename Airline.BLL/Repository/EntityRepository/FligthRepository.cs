using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    public class FligthRepository : Repository<Fligth>, IFligthRepository
    {
        public FligthRepository(DbContext context) : base(context) { }

        public IQueryable<Fligth> GetFligthAdminDisp()
        {
            return _dbSet.Include(f => f.FromCity).Include(f => f.WhereCity)
                .Include(r => r.FromCity.Country).Include(t => t.WhereCity.Country).AsNoTracking();
        }
        public IQueryable<Fligth> GetFligthAllUsers()
        {
            return _dbSet.Include(f => f.FromCity).Include(f => f.WhereCity)
                .Include(r => r.FromCity.Country).Include(t => t.WhereCity.Country).Where(confirm=>confirm.IsConfirmed).AsNoTracking();
        }

    }
}
