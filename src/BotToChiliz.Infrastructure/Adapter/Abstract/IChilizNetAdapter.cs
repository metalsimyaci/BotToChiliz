using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chiliz.Net.Interfaces;
using Chiliz.Net.Objects;

namespace BotToChiliz.Infrastructure.Adapter.Abstract
{
    public interface IChilizNetAdapter
    {
        Task<ChilizOrder> GetOrderAsync(long orderId, string orderClientId, CancellationToken cancellationToken);
        Task<IEnumerable<ChilizOrder>> GetOrdersAsync(string symbol, CancellationToken cancellationToken);
        Task<IEnumerable<ChilizOrder>> GetOpenOrdersAsync(string symbol,CancellationToken cancellationToken);
        Task<ChilizOrderBook> GetOrderBookAsync(string symbol, CancellationToken cancellationToken);
        Task<IEnumerable<ChilizBookPrice>> GetAllBookPricesAsync(CancellationToken cancellationToken);
        Task<ChilizPlacedOrder> BuyOrderAsync(string symbol, decimal quantity, decimal price, CancellationToken cancellationToken);
        Task<ChilizPlacedOrder> SellOrderAsync(string symbol, decimal quantity, decimal price, CancellationToken cancellationToken);
        Task<ChilizCanceledOrder> CancelOrderAsync(long orderId, string clientOrderId,CancellationToken cancellationToken);
        Task<ChilizAccountInfo> GetAccountInfo(CancellationToken cancellationToken);
    }
}