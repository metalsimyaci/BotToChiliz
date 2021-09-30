using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Abstraction.DependencyInjection.Abstract
{
    public interface IDependencyBuilder
    {
        IServiceCollection Services { get; }
        IDependencyContext Context { get; }
    }
}