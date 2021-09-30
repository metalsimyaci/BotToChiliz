using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.DataAccess.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Context
{
    public class DataContext : Abstraction.DataAccess.EntityFramework.Abstract.Context
    {
        #region Properties

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyBalance> CurrencyBalances { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkerOrder> WorkerOrders { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        #endregion

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyBalanceConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerOrderConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            DataInitializer.Initialize(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


    }
}