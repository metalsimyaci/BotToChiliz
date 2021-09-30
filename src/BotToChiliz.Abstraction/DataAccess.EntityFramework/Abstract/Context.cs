using Microsoft.EntityFrameworkCore;

namespace BotToChiliz.Abstraction.DataAccess.EntityFramework.Abstract
{
    public abstract class Context:DbContext,IContext
    {
        protected Context(DbContextOptions options):base(options)
        {
            
        }
    }
}