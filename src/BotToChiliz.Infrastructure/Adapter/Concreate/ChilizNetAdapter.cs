using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Infrastructure.Adapter.Abstract;
using BotToChiliz.Infrastructure.Adapter.Configuration;
using Chiliz.Net;
using Chiliz.Net.Interfaces;
using Chiliz.Net.Objects;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Options;

namespace BotToChiliz.Infrastructure.Adapter.Concreate
{
    public class ChilizNetAdapter:IChilizNetAdapter
    {
        private readonly IChilizClient _client;
        private readonly ChilizClientConfiguration _config;
        public ChilizNetAdapter(IChilizClient client,IOptions<ChilizClientConfiguration> options)
        {
            _client = client;
            _config = options.Value;
        }

        public async Task<IEnumerable<ChilizOrder>> GetOrdersAsync(string symbol, CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var a = await _client.GetAllOrdersAsync(symbol, ct: cancellationToken, receiveWindow: 5000);
            if(a.Success)
                return a.Data;
            return null;
        }
        public async Task<IEnumerable<ChilizOrder>> GetOrdersAsync(string symbol, CancellationToken cancellationToken)
        {
            _client.SetApiCredentials(_config.ApiKey,_config.SecretKey);
            var a = await _client.getor(symbol, ct: cancellationToken, receiveWindow: 5000);
            if(a.Success)
                return a.Data;
            return null;
        }
    }
}
