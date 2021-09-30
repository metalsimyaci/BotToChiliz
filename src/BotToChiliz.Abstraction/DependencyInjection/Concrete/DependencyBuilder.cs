using BotToChiliz.Abstraction.DependencyInjection.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Abstraction.DependencyInjection.Concrete
{
    public class DependencyBuilder : IDependencyBuilder
    {
        #region Properties

        public IServiceCollection Services { get; }
        public IDependencyContext Context { get; }

        #endregion

        public DependencyBuilder(IServiceCollection services)
        {
            Services = services;
            Context = new DependencyContext(services);
        }
    }
}