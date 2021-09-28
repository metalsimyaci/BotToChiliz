using BotToChiliz.Domain.Data.Abstract.Audited;
using BotToChiliz.Domain.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Abstract.Configuration
{
    public abstract class FullAuditedConfigurationBase<TEntity> where TEntity:class,IFullAudited
    {
        protected virtual void ConfigureAudit(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.CreationTime).ValueGeneratedOnAdd().IsRequired().HasValueGenerator<DateTimeValueGenerator>();
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(Constants.CreatedByMaxLength);

            builder.Property(p => p.ModificationTime).ValueGeneratedOnUpdate().IsRequired(false).HasValueGenerator<DateTimeValueGenerator>();
            builder.Property(p => p.ModifiedBy).IsRequired(false).HasMaxLength(Constants.ModifiedByMaxLength);

            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.DeletionTime).IsRequired(false);
            builder.Property(p => p.DeletedBy).IsRequired(false).HasMaxLength(Constants.DeletedByMaxLength);
        }
    }
}