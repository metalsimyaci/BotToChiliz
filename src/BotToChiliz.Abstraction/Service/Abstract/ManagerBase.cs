using System;
using BotToChiliz.Abstraction.DependencyInjection.Abstract;

namespace BotToChiliz.Abstraction.Service.Abstract
{
    public abstract class ManagerBase:IManager,IDisposable
    {

        protected IDependencyContext DependenctContext { get; set; }
        private bool _disposed;

        public ManagerBase(IDependencyContext dependencyContext)
        {
            DependenctContext = dependencyContext;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                DependenctContext = null;
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
