using BotToChiliz.Domain.Data.Abstract.Audited;
using BotToChiliz.Domain.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Abstract.Configuration
{
    public abstract class AuditedConfigurationBase<TEntity> where TEntity:class,IAudited
    {
        protected virtual void ConfigureAudit(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.CreationTime).ValueGeneratedOnAdd().IsRequired().HasValueGenerator<DateTimeValueGenerator>(); ;
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(Constants.CreatedByMaxLength);

            builder.Property(p => p.ModificationTime).ValueGeneratedOnUpdate().IsRequired(false).HasValueGenerator<DateTimeValueGenerator>();
            builder.Property(p => p.ModifiedBy).IsRequired(false).HasMaxLength(Constants.ModifiedByMaxLength);
        }
    }
}
