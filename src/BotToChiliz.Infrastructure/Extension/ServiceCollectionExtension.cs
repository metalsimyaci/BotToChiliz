using BotToChiliz.Infrastructure.Adapter.Abstract;
using BotToChiliz.Infrastructure.Adapter.Concreate;
using BotToChiliz.Infrastructure.Adapter.Configuration;
using Chiliz.Net;
using Chiliz.Net.Interfaces;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BotToChiliz.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var _configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddOptions<ChilizClientConfiguration>();
            services.Configure<ChilizClientConfiguration>(_configuration.GetSection(nameof(ChilizClientConfiguration)));
            services.AddTransient<IChilizClient>(s =>
            {
                var options = s.GetService<IOptions<ChilizClientConfiguration>>().Value;
                return new ChilizClient(new ChilizClientOptions()
                {
                    BaseAddress = options.BaseAddress,
                    //ApiCredentials = new ApiCredentials(options.ApiKey,options.SecretKey)
                });
            });
            services.AddTransient<IChilizNetAdapter, ChilizNetAdapter>();
            return services;
        }
    }
}