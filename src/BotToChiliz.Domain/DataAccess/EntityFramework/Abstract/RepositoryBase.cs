using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Domain.Data.Abstract;
using BotToChiliz.Domain.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Abstract
{
    public class RepositoryBase<TContext, TEntity, T> : IRepository<TContext, TEntity, T>
        where TContext : EfDbContext
        where TEntity : EntityBase<T>
    {
        #region Constants

        private const int BulkOperationTreshold = 100;
        private const string IsDeletedPropertyName = "IsDeleted";

        #endregion

        #region Variables

        private bool _disposed;

        #endregion

        #region Properties

        protected TContext Context { get; private set; }

        #endregion

        #region Methods

        #region IRepository<T> Implementation

        public void UseContext(TContext dbContext)
        {
            Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext), $@"'{nameof(dbContext)}' null olamaz!");
        }

        public virtual async Task<TEntity> GetAsync(T id, CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(p => p.Id.Equals(id), navigationProperties).SingleOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(filter, navigationProperties).SingleOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<int> GetCountAsync(CancellationToken cancellationToken)
        {
            return await GetQueryable(null, null).CountAsync(cancellationToken);
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await GetQueryable(filter, null).CountAsync(cancellationToken);
        }

        public virtual async Task<long> GetLongCountAsync(CancellationToken cancellationToken)
        {
            return await GetQueryable(null, null).LongCountAsync(cancellationToken);
        }

        public virtual async Task<long> GetLongCountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await GetQueryable(filter, null).LongCountAsync(cancellationToken);
        }

        public virtual async Task<bool> ExistsAsync(CancellationToken cancellationToken)
        {
            return await GetQueryable(null, null).AnyAsync(cancellationToken);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await GetQueryable(filter, null).AnyAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(filter, navigationProperties).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, int? skip, CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(filter, null, skip, null, navigationProperties).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken,
            params string[] navigationProperties)
        {
            return await GetQueryable(filter, orderBy, null, null, navigationProperties).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip,
            CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(filter, orderBy, skip, null, navigationProperties).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(null, navigationProperties).ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(filter, navigationProperties).ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken,
            params string[] navigationProperties)
        {
            return await GetQueryable(filter, orderBy, null, null, navigationProperties).ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip, int? take,
            CancellationToken cancellationToken, params string[] navigationProperties)
        {
            return await GetQueryable(filter, orderBy, skip, take, navigationProperties).ToListAsync(cancellationToken);
        }

        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            CheckContext();
            Context.Set<TEntity>().Add(entity);
            return await Task.FromResult(true);
        }

        public virtual async Task<bool> InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {

            CheckContext();

            List<TEntity> entityList = entities as List<TEntity> ?? entities.ToList();

            if (entityList.All(e => e == null))
                return true;

            Context.Set<TEntity>().AddRange(entityList.Where(e => e != null));
            await Context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            CheckContext();

            TEntity dbEntity = await Context.Set<TEntity>().FindAsync(entity.Id);
            EntityEntry<TEntity> entry = Context.ChangeTracker.Entries<TEntity>().FirstOrDefault(e => e.Entity.Id.Equals(entity.Id) && e.State!=EntityState.Detached) ?? Context.Entry(dbEntity);

            entry.CurrentValues.SetValues(entity);

            entry.State = EntityState.Modified;
            return true;
        }

        public virtual async Task<bool> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {

            CheckContext();

            List<TEntity> entityList = entities as List<TEntity> ?? entities.ToList();

            if (entityList.All(e => e == null))
                return true;

            foreach (TEntity entity in entityList)
            {
                TEntity dbEntity = await Context.Set<TEntity>().FindAsync(entity.Id);
                EntityEntry<TEntity> entry = Context.ChangeTracker.Entries<TEntity>().FirstOrDefault(e => e.Entity.Id.Equals(entity.Id)) ?? Context.Entry(dbEntity);

                entry.CurrentValues.SetValues(entity);
                entry.State = EntityState.Modified;
            }

            return true;
        }

        public virtual async Task<bool> InsertOrUpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            CheckContext();

            TEntity dbEntity = await Context.FindAsync<TEntity>(new object[] { entity.Id }, cancellationToken);

            if (dbEntity == null)
                Context.Set<TEntity>().Add(entity);
            else
                Context.Entry(dbEntity).CurrentValues.SetValues(entity);

            return true;
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {

            CheckContext();

            TEntity entity = await Context.Set<TEntity>().FindAsync(keyValues, cancellationToken);

            return await DeleteAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            PropertyInfo propertyInfo = typeof(TEntity).GetProperty(IsDeletedPropertyName);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entity, true);
                return await UpdateAsync(entity);
            }

            CheckContext();

            DbSet<TEntity> dbSet = Context.Set<TEntity>();

            if (Context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            List<TEntity> entityList = entities as List<TEntity> ?? entities.ToList();

            if (entityList.All(e => e == null))
                return true;

            CheckContext();

            DbSet<TEntity> dbSet = Context.Set<TEntity>();
            PropertyInfo propertyInfo = typeof(TEntity).GetProperty(IsDeletedPropertyName);

            foreach (TEntity entity in entityList)
            {
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entity, true);

                    if (Context.Entry(entity).State == EntityState.Detached)
                        dbSet.Attach(entity);

                    Context.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    if (Context.Entry(entity).State == EntityState.Detached)
                        dbSet.Attach(entity);

                    dbSet.Remove(entity);
                }
            }

            return true;
        }

        #endregion

        #region IDisposable Implementation

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion


        protected virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter, string[] navigationProperties)
        {
            CheckContext();
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (navigationProperties != null && navigationProperties.Any())
                foreach (string navigationProperty in navigationProperties)
                    if (!String.IsNullOrWhiteSpace(navigationProperty))
                        query = query.Include(navigationProperty);

            return query.AsNoTracking();
        }

        protected virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip, int? take,
            string[] navigationProperties)
        {
            CheckContext();

            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (navigationProperties != null && navigationProperties.Any())
                foreach (string navigationProperty in navigationProperties)
                    if (!String.IsNullOrWhiteSpace(navigationProperty))
                        query = query.Include(navigationProperty);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return query.AsNoTracking();
        }

        protected void CheckContext()
        {
            if (Context == null)
                throw new Exception($"{nameof(Context)} cannot be null!");
        }

        #endregion
    }
}