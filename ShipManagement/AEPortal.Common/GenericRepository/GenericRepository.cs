using AEPortal.Common.BaseEntities;
using AEPortal.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AEPortal.Common.GenericRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Deletes(IEnumerable<Guid> ids);
        void Deletes(IEnumerable<T> entites);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        IQueryable<T> All();
        IQueryable<T> Seach();
        Task<bool> Any(Expression<Func<T, bool>> expression);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        ValueTask<T> GetById(Guid id);
        IQueryable<T> Include(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        void AddRange(IEnumerable<T> data);
    }

    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(TContext context)
        {

            _dbSet = context.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Deletes(IEnumerable<Guid> ids)
        {
            var entities = _dbSet.Where(i => ids.Contains(i.Id));
            if (entities is null)
            {
                throw new NotFoundException();
            }
            _dbSet.RemoveRange(entities);

        }

        public void Deletes(IEnumerable<TEntity> entites)
        {
            _dbSet.RemoveRange(entites);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public IQueryable<TEntity> All()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> Seach()
        {
            return _dbSet.AsQueryable();
        }

        public Task<bool> Any(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.AnyAsync(expression);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public ValueTask<TEntity> GetById(Guid id)
        {
            return _dbSet.FindAsync(id);
        }

        public void AddRange(IEnumerable<TEntity> data)
        {
            _dbSet.AddRange(data);
        }

        public IQueryable<TEntity> Include(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            IQueryable<TEntity> query = _dbSet;
            query = include(query);
            return query;
        }
    }

}
