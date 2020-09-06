using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Airline.BLL.Repository
{
    public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<TEntity> GetById(int? id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.AsEnumerable().Where(predicate).ToList();
        }

        private IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _dbSet.AsTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
    }
}
