using System;
using System.Threading;
using System.Threading.Tasks;

namespace BotToChiliz.Abstraction.DataAccess.Abstract
{
    internal interface IUnitOfWork : IDisposable
    {
        #region Methods

        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> BeginTransactionAsync(CancellationToken cancellationToken);
        void RollbackTransaction();
        Task<bool> CommitTransactionAsync(CancellationToken cancellationToken);
        void SetDbCommandTimeout(int timeOut);
        void RevertDbCommandTimeout();
        void SetDbCommandTimeoutToDefault();

        #endregion
    }
}
