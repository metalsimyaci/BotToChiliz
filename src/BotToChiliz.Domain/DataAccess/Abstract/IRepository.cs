using BotToChiliz.Domain.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BotToChiliz.Domain.DataAccess.Abstract
{
    public interface IRepository<in TContext, TEntity, T> : IDisposable
        where TContext : IDbContext
        where TEntity : IEntity<T>
    {
        #region Methods

        void UseContext(TContext dbContext);

        Task<TEntity> GetAsync(T id, CancellationToken cancellationToken, params string[] navigationProperties);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken, params string[] navigationProperties);

        Task<int> GetCountAsync(CancellationToken cancellationToken);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
        Task<long> GetLongCountAsync(CancellationToken cancellationToken);
        Task<long> GetLongCountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);

        Task<bool> ExistsAsync(CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken, params string[] navigationProperties);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, int? skip, CancellationToken cancellationToken, params string[] navigationProperties);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken,
            params string[] navigationProperties);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip, 
            CancellationToken cancellationToken, params string[] navigationProperties);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken, params string[] navigationProperties);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken, params string[] navigationProperties);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken,
            params string[] navigationProperties);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip, int? take, 
            CancellationToken cancellationToken, params string[] navigationProperties);

        Task<bool> InsertAsync(TEntity entity);
        Task<bool> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        Task<bool> InsertOrUpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        #endregion
    }
}
