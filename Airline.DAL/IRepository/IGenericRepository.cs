using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DAL.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class //, IEntity
    {
        Task Create(TEntity entity);
        Task<TEntity> GetById(int? id);
        IEnumerable<TEntity> Get();
        Task Delete(int id);
        Task Update(int id, TEntity entity);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        //  void Save();

    }
}
