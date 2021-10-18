using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BotToChiliz.Infrastructure.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Console
{
    public class Program
    {
        #region Constants

        private const string SYMBOL_NAME = "VIT";

        #endregion

        #region Properties

        private static IConfiguration _configuration;
        private static IServiceProvider _serviceProvider;

        #endregion
        
        public static async Task Main(string[] args)
        {
            try
            {
                SetServices();

                var manager = _serviceProvider.GetRequiredService<ChilizManager>();
                await manager.GetAccountInfo();
                
                System.Console.ReadLine();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
            
        }

        #region Private Methods

        private static void SetServices()
        {
            GetConfiguration();
            var services = new ServiceCollection();
            services.AddSingleton(_=>_configuration);
            services.AddInfrastructure();
            services.AddTransient<ChilizManager>();
            _serviceProvider = services.BuildServiceProvider();
        }
        private static void GetConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(),optional:true,reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();
        }
        
        
        #endregion
    }
}