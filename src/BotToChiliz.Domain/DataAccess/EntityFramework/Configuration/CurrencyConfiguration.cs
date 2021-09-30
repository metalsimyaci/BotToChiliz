using BotToChiliz.Abstraction.DataAccess.EntityFramework.Abstract.Configuration;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Configuration
{
    public class CurrencyConfiguration:FullAuditedConfigurationBase<Currency>, IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currencies", Constants.SCHEME_NAME);
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(Constants.CURRENCY_CODE_MAX_LENGTH);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(Constants.CURRENCY_NAME_MAX_LENGTH);
            builder.Property(p => p.Definition).IsRequired(false).HasMaxLength(Constants.CURRENCY_DEFINITION_MAX_LENGTH);
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(1).HasDefaultValueSql("0");

            base.ConfigureAudit(builder);

            //Index
            builder.HasIndex(p => p.Code, "IX_Currency_Code");
        }
    }
}