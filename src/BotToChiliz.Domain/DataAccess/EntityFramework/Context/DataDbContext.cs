using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.DataAccess.EntityFramework.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Context
{
    public class DataDbContext : EfDbContext
    {
        #region Properties

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyBalance> CrCurrencyBalances { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkerOrder> WorkerOrders { get; set; }


        #endregion

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new SmsTemplateConfiguration());
            //modelBuilder.ApplyConfiguration(new SmsBlockConfiguration());
            //modelBuilder.ApplyConfiguration(new RecipientSmsConfiguration());
            //modelBuilder.ApplyConfiguration(new LogConfiguration());
            DataInitializer.Initialize(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


    }
}