using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chiliz.Net.Interfaces;
using Chiliz.Net.Objects;

namespace BotToChiliz.Infrastructure.Adapter.Abstract
{
    public interface IChilizNetAdapter
    {
        Task<IEnumerable<ChilizOrder>> GetOrdersAsync(string symbol, CancellationToken cancellationToken);
        Task<ChilizAccountInfo> GetAccountInfo(CancellationToken cancellationToken);
    }
}