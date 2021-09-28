using BotToChiliz.Domain.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Abstract
{
    public abstract class EfDbContext:DbContext,IDbContext
    {
        protected EfDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}