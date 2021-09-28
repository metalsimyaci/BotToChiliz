using BotToChiliz.Domain.Data.Abstract;
using BotToChiliz.Domain.DataAccess.EntityFramework.Abstract;
using BotToChiliz.Domain.DataAccess.EntityFramework.Context;
using Microsoft.VisualBasic;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Repository
{
    public class BotRepository<TType, TEntity>:
        RepositoryBase<DataContext,TType,TEntity>,
        IBotRepository<TType,TEntity>
        where TEntity : EntityBase<TType>
    {
        
    }
}