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

        public IConfiguration _configuration;
        protected internal IServiceProvider _serviceProvider;

        #endregion
        
        private void GetConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(),optional:true,reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void SetServices()
        {
            GetConfiguration();
            var services = new ServiceCollection();
            services.AddSingleton(_=>_configuration);
            services.AddInfrastructure();
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}