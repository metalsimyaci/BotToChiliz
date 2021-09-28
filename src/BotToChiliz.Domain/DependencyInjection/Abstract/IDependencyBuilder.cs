using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Domain.DependencyInjection.Abstract
{
    public interface IDependencyBuilder
    {
        IServiceCollection Services { get; }
        IDependencyContext Context { get; }
    }
}