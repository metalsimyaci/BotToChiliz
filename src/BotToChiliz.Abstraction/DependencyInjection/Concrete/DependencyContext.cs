using System;
using BotToChiliz.Abstraction.DependencyInjection.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Abstraction.DependencyInjection.Concrete
{
    public class DependencyContext:IDependencyContext
    {
        #region Properties

        public IServiceCollection Services { get; }
        public IServiceProvider ServiceProvider { get; set; }

        IServiceCollection IDependencyContext.Services => throw new NotImplementedException();

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