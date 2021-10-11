using System;
using System.IO;
using System.Reflection;
using BotToChiliz.Infrastructure.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Console
{
    public class Botto
    {
        #region Properties

        private IConfiguration _configuration;
        protected internal IServiceProvider _serviceProvider;

        #endregion
        
        public void GetConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets(Assembly.GetExecutingAssembly(),optional:true,reloadOnChange:true)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void SetServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IConfiguration>(s => _configuration);
            services.AddInfrastructure(_configuration);
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}