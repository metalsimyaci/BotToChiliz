using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Infrastructure.Adapter.Abstract;
using Chiliz.Net;
using Chiliz.Net.Interfaces;
using Chiliz.Net.Objects;

namespace BotToChiliz.Infrastructure.Adapter.Concreate
{
    public class ChilizNetAdapter:IChilizNetAdapter
    {
        #region Variables

        private readonly IChilizClient _client;

        #endregion

        #region Methods

        #region Constructor

        public ChilizNetAdapter(IChilizClient client)
        {
            _client = client;
        }

        #endregion

        #region Public Methods

        public async Task<ChilizOrder> GetOrderAsync(long orderId, string orderClientId, CancellationToken cancellationToken)
        {
            var response = await _client.GetOrderAsync(orderId,orderClientId, ct: cancellationToken, receiveWindow: 5000);
            if(response.Success)
                return response.Data;
            return null;
        }
        public async Task<IEnumerable<ChilizOrder>> GetOrdersAsync(string symbol, CancellationToken cancellationToken)
        {
            var response = await _client.GetAllOrdersAsync(symbol, ct: cancellationToken, receiveWindow: 5000);
            if(response.Success)
                return response.Data;
            return null;
        }

        public async Task<IEnumerable<ChilizOrder>> GetOpenOrdersAsync(string symbol,CancellationToken cancellationToken)
        {
            var response = await _client.GetOpenOrdersAsync(symbol,ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }

        public async Task<ChilizOrderBook> GetOrderBookAsync(string symbol, CancellationToken cancellationToken)
        {
            var response = await _client.GetOrderBookAsync(symbol, ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }

        public async Task<IEnumerable<ChilizBookPrice>> GetAllBookPricesAsync(CancellationToken cancellationToken)
        {
            var response = await _client.GetAllBookPricesAsync( ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }

        public async Task<ChilizPlacedOrder> BuyOrderAsync(string symbol, decimal quantity, decimal price, CancellationToken cancellationToken)
        {
            return await PostPlaceOrderAsync(symbol, OrderSide.Buy, quantity, price, cancellationToken);
        }

        public async Task<ChilizPlacedOrder> SellOrderAsync(string symbol, decimal quantity, decimal price, CancellationToken cancellationToken)
        {
            return await PostPlaceOrderAsync(symbol, OrderSide.Sell, quantity, price, cancellationToken);
        }

        public async Task<ChilizCanceledOrder> CancelOrderAsync(long orderId, string clientOrderId,CancellationToken cancellationToken)
        {
            var response = await _client.CancelOrderAsync(orderId,clientOrderId, ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }
        
        public async Task<ChilizAccountInfo> GetAccountInfo(CancellationToken cancellationToken)
        {
            var response = await _client.GetAccountInfoAsync(null, cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }

        #endregion

        #region Private Methods

        private async Task<ChilizPlacedOrder> PostPlaceOrderAsync(string symbol,OrderSide side,decimal quantity,decimal price,CancellationToken cancellationToken)
        {
            var response = await _client.PlaceOrderAsync(symbol,side,OrderType.Limit,TimeInForce.GoodTillCancel,quantity,price, ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }
        private async Task<DateTime?> GetServerTimeAsync(CancellationToken cancellationToken)
        {
            var response = await _client.GetServerTimeAsync(ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }

        #endregion

        #endregion
    }
}
