using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Domain.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Abstract
{
    public class UnitOfWorkBase<TContext> : IUnitOfWork
    where TContext : Context
    {
        #region Variables

        protected readonly TContext Context;
        private int? _previousCommandTimeout;
        private bool _disposed;

        #endregion

        #region Methods

        #region Constructors

        protected UnitOfWorkBase(TContext dbContext)
        {
            Context = dbContext;
        }

        protected UnitOfWorkBase()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUnitOfWork Implementation

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {

            if (Context.ChangeTracker.HasChanges())
                await Context.SaveChangesAsync(cancellationToken);

            return true;

        }

        public async Task<bool> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            if (Context.Database.CurrentTransaction == null)
            {
                DbConnection dbConnection = Context.Database.GetDbConnection();

                if (dbConnection.State != ConnectionState.Open)
                    await dbConnection.OpenAsync(cancellationToken);

                await Context.Database.BeginTransactionAsync(cancellationToken);
            }

            return true;

        }

        public void RollbackTransaction()
        {
            Context.Database.CurrentTransaction?.Rollback();

        }

        public async Task<bool> CommitTransactionAsync(CancellationToken cancellationToken)
        {

            await SaveChangesAsync(cancellationToken);
            Context.Database.CurrentTransaction?.Commit();
            return true;

        }

        public void SetDbCommandTimeout(int timeout)
        {
            _previousCommandTimeout = Context.Database.GetCommandTimeout();

            if (timeout < 0)
                Context.Database.SetCommandTimeout(null);
            else
                Context.Database.SetCommandTimeout(timeout);
        }

        public void RevertDbCommandTimeout()
        {
            Context.Database.SetCommandTimeout(_previousCommandTimeout);
        }

        public void SetDbCommandTimeoutToDefault()
        {
            _previousCommandTimeout = Context.Database.GetCommandTimeout();
            Context.Database.SetCommandTimeout(null);
        }

        #endregion

        #region IDisposable Implementation

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Context != null)
                    {
                        if (Context.ChangeTracker?.HasChanges()??false)
                            Context.SaveChanges();

                        Context.Database?.CurrentTransaction?.Commit();
                        Context.Database?.CurrentTransaction?.Dispose();
                        if (Context.Database?.CanConnect() ?? false)
                            Context.Database?.CloseConnection();
                    }
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

        #endregion
    }
}