using BotToChiliz.Abstraction.Data;
using BotToChiliz.Abstraction.DataAccess.EntityFramework.Abstract;
using BotToChiliz.Domain.DataAccess.EntityFramework.Context;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Repository
{
    public class BotRepository<TType, TEntity>:RepositoryBase<DataContext,TType,TEntity>, IBotRepository<TType,TEntity> 
        where TEntity : EntityBase<TType>
    {
        
    }
}