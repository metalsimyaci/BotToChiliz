using System;
using BotToChiliz.Abstraction.DependencyInjection.Abstract;
using BotToChiliz.Abstraction.DependencyInjection.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Abstraction.DependencyInjection.Extension
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder AddInfrastructure(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var builder = new DependencyBuilder(services);
            services.AddOptions();
            services.AddSingleton(typeof(IDependencyContext), _ => builder.Context);

            return builder;
        }

        //public static DependencyBuilder AddDomain(this DependencyBuilder builder)
        //{

        //    #region Validator

        //    builder.Services.AddValidatorsFromAssemblyContaining<WorkerValidator>();

        //    #endregion

        //    #region Mapping

        //    builder.Services.AddAutoMapper(o =>
        //    {
        //        o.AddProfile<BotProfile>();
        //    });

        //    #endregion

        //    #region Manager

        //    builder.Services.TryAddTransient<IBotManager,BotManager>();

        //    #endregion

        //    builder.Services.BuildServiceProvider();
        //    return builder;
        //}
    }
}