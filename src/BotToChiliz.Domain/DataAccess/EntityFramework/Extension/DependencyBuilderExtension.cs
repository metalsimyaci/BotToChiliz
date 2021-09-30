using BotToChiliz.Abstraction.DependencyInjection.Concrete;
using BotToChiliz.Domain.DataAccess.EntityFramework.Repository;
using BotToChiliz.Domain.DataAccess.EntityFramework.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataContext = BotToChiliz.Domain.DataAccess.EntityFramework.Context.DataContext;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Extension
{
    public static class DependencyBuilderExtension
    {
        private const string CONNECTION_STRING_NAME = "";
        private const string SERVER_VERSION = "";

        public static DependencyBuilder AddDataAccess(this DependencyBuilder builder,IConfiguration configuration)
        {
            builder.Services.AddDbContext<DataContext>(s =>
                s.UseMySql(connectionString: configuration.GetConnectionString(CONNECTION_STRING_NAME),
                    new MySqlServerVersion(SERVER_VERSION)));
            builder.Services.AddTransient(typeof(IBotRepository<,>), typeof(BotRepository<,>));
            builder.Services.AddTransient(typeof(IBotUnitOfWork), typeof(BotUnitOfWork));
            builder.Context.BuildServiceProvider();
            return builder;
        }
    }
}
