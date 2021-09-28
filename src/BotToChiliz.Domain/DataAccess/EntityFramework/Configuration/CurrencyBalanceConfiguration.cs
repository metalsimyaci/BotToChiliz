using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.DataAccess.EntityFramework.Abstract.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Configuration
{
    internal class CurrencyBalanceConfiguration:CreationAuditedConfigurationBase<CurrencyBalance>, IEntityTypeConfiguration<CurrencyBalance>
    {
        public void Configure(EntityTypeBuilder<CurrencyBalance> builder)
        {
            builder.ToTable("CurrencyBalances", Constants.DB_SCHEME_NAME);
            builder.HasKey(k => k.Id);

            builder.Property(p => p.CurrencyId).IsRequired();
            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.Balance).IsRequired();

            base.ConfigureAudit(builder);

            //Index
            builder.HasIndex(p =>new{p.CurrencyId,p.Type}, "IX_CurrencyBalance_CurrencyIdType");

            //Relations
            builder.HasOne(h => h.Currency).WithMany(m => m.CurrencyBalances).HasForeignKey(k => k.CurrencyId);
        }
    }
}
