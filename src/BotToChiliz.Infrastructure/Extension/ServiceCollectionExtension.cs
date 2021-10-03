using BotToChiliz.Infrastructure.Adapter.Configuration;
using Chiliz.Net;
using Chiliz.Net.Interfaces;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BotToChiliz.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IOptions<ChilizClientConfiguration> options)
        {
            services.AddOptions<ChilizClientConfiguration>();
            services.ConfigureOptions<ChilizClientConfiguration>();
            services.AddTransient<IChilizClient>(s => new ChilizClient(new ChilizClientOptions
            {
                BaseAddress = options.Value.BaseAddress
            }));
            return services;
        }
    }
}