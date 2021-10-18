using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Infrastructure.Adapter.Abstract;
using BotToChiliz.Infrastructure.Adapter.Configuration;
using Chiliz.Net;
using Chiliz.Net.Interfaces;
using Chiliz.Net.Objects;
using Microsoft.Extensions.Options;

namespace BotToChiliz.Infrastructure.Adapter.Concreate
{
    public class ChilizNetAdapter:IChilizNetAdapter
    {
        private readonly IChilizClient _client;
        private readonly ChilizClientConfiguration _config;
        public ChilizNetAdapter(IChilizClient chilizClient, IOptions<ChilizClientConfiguration> options)
        {
            _client = chilizClient;
            _config = options.Value;
        }

        public async Task<IEnumerable<ChilizOrder>> GetOrdersAsync(string symbol, CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var response = await _client.GetAllOrdersAsync(symbol, ct: cancellationToken, receiveWindow: 5000);
            if(response.Success)
                return response.Data;
            return null;
        }
        private async Task<IEnumerable<ChilizOrder>> GetOpenOrdersAsync(string symbol,CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var response = await _client.GetOpenOrdersAsync(symbol,ct: cancellationToken);
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
        public async Task<IEnumerable<ChilizBookPrice>> GetAllBookPricesAsync(CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var response = await _client.GetAllBookPricesAsync( ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }

        public async Task<ChilizPlacedOrder> BuyOrderAsync(string symbol, decimal quantity, decimal price,
            CancellationToken cancellationToken)
        {
            return await PostPlaceOrderAsync(symbol, OrderSide.Buy, quantity, price, cancellationToken);
        }
        public async Task<ChilizPlacedOrder> SellOrderAsync(string symbol, decimal quantity, decimal price,
            CancellationToken cancellationToken)
        {
            return await PostPlaceOrderAsync(symbol, OrderSide.Sell, quantity, price, cancellationToken);
        }
        private async Task<ChilizPlacedOrder> PostPlaceOrderAsync(string symbol,OrderSide side,decimal quantity,decimal price,CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var response = await _client.PlaceOrderAsync(symbol,side,OrderType.Limit,TimeInForce.GoodTillCancel,quantity,price, ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }
        private async Task<ChilizCanceledOrder> CancelOrderAsync(long orderId, string clientOrderId,CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var response = await _client.CancelOrderAsync(orderId,clientOrderId, ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }
        
        public async Task<ChilizOrderBook> GetOrderBookAsync(string symbol, CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var response = await _client.GetOrderBookAsync(symbol, ct: cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }
        public async Task<ChilizAccountInfo> GetAccountInfo(CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var response = await _client.GetAccountInfoAsync(null, cancellationToken);
            if(response.Success)
                return response.Data;
            return null;
        }
    }
}
