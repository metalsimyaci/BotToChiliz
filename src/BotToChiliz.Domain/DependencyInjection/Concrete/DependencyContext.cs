using System;
using BotToChiliz.Domain.DependencyInjection.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Domain.DependencyInjection.Concrete
{
    public class DependencyContext:IDependencyContext
    {
        #region Properties

        public IServiceCollection Services { get; }
        public IServiceProvider ServiceProvider { get; set; }

        public DependencyContext(IServiceCollection services)
        {
            Services = services;
        }
        #endregion

        public void BuildServiceProvider()
        {
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}