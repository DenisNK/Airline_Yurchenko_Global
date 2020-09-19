using System;
using System.Linq;
using Airline.DAL.IRepository.IEntityRepository;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository.EntityRepository
{
    class RequsetRepository : Repository<Request>, IRequsetRepository
    {
        public RequsetRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Request> GetListProblem(string id)
        {
            return _dbSet.Where(sign => sign.SignIn == id);
        }
    }
}
