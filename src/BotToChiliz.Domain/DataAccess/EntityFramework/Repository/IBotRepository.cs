using BotToChiliz.Abstraction.Data.Abstract;
using BotToChiliz.Abstraction.DataAccess.Abstract;
using BotToChiliz.Domain.DataAccess.EntityFramework.Context;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Repository
{
    internal interface IBotRepository<in TType, TEntity>:IRepository<DataContext, TType, TEntity>
        where TEntity : EntityBase<TType>
    {
        
    }
}