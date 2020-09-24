using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline.DAL.IRepository.IEntityRepository
{
    public interface IFligthRepository:IGenericRepository<Fligth>
    {
        IQueryable<Fligth> GetFligthAdminDisp(string name);
        IQueryable<Fligth> GetFligthAllUsers();
        IQueryable<Fligth> GetFligthAdmin();
        Task<Fligth> GetFligthByIdAsync(int? id);
        
    }
}
