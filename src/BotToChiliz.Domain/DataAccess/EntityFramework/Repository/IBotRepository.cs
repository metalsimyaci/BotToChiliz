using BotToChiliz.Abstraction.Data;
using BotToChiliz.Abstraction.DataAccess;
using BotToChiliz.Domain.DataAccess.EntityFramework.Context;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Repository
{
    public interface IBotRepository<in TType, TEntity>:IRepository<DataContext, TType, TEntity>
        where TEntity : EntityBase<TType>
    {
        
    }
}