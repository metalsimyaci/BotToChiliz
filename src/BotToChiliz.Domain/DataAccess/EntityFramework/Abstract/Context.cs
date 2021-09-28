using BotToChiliz.Domain.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Abstract
{
    public abstract class Context:DbContext,IContext
    {
        protected Context(DbContextOptions options):base(options)
        {
            
        }
    }
}