using BotToChiliz.Abstraction.DataAccess.EntityFramework.Abstract.Configuration;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.Data.Enumeration;
using BotToChiliz.Domain.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Configuration
{
    internal class CurrencyBalanceConfiguration:CreationAuditedConfigurationBase<CurrencyBalance>, IEntityTypeConfiguration<CurrencyBalance>
    {
        public void Configure(EntityTypeBuilder<CurrencyBalance> builder)
        {
            builder.ToTable("CurrencyBalances", Constants.SCHEME_NAME);
            builder.HasKey(k => k.Id);

            builder.Property(p => p.CurrencyId).IsRequired();
            builder.Property(p => p.Type).IsRequired().HasConversion<EnumToStringConverter<BalanceTypes>>();
            builder.Property(p => p.Balance).IsRequired();

            base.ConfigureAudit(builder);

            //Index
            builder.HasIndex(p =>new{p.CurrencyId,p.Type}, "IX_CurrencyBalance_CurrencyIdType");

            //Relations
            builder.HasOne(h => h.Currency).WithMany(m => m.CurrencyBalances).HasForeignKey(k => k.CurrencyId);
        }
    }
}
