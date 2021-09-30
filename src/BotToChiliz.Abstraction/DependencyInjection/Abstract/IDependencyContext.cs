using System;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Abstraction.DependencyInjection.Abstract
{
    public interface IDependencyContext
    {
        IServiceCollection Services { get; }
        IServiceProvider ServiceProvider { get; set; }
        void BuildServiceProvider();
    }
}