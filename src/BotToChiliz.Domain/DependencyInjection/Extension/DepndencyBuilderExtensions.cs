using System;
using BotToChiliz.Domain.DependencyInjection.Abstract;
using BotToChiliz.Domain.DependencyInjection.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Domain.DependencyInjection.Extension
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder AddInfrastructure(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            DependencyBuilder builder = new DependencyBuilder(services);
            services.AddOptions();
            services.AddSingleton(typeof(IDependencyContext), s => builder.Context);

            return builder;
        }
    }
}