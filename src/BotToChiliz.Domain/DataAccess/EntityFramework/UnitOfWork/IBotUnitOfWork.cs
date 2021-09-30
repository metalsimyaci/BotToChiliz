using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.Data.Enumeration;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.UnitOfWork
{
    public interface IBotUnitOfWork:IDisposable
    {
        Task<IEnumerable<Worker>> ReadWorkersAsync(WorkerType type, CancellationToken cancellationToken);
    }
}