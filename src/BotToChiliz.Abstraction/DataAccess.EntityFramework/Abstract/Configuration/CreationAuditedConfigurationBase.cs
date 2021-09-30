using BotToChiliz.Abstraction.Data.Abstract.Audited;
using BotToChiliz.Abstraction.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotToChiliz.Abstraction.DataAccess.EntityFramework.Abstract.Configuration
{
    public class CreationAuditedConfigurationBase<TEntity> where TEntity : class, ICreationAudited
    {
        protected virtual void ConfigureAudit(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.CreationTime).ValueGeneratedOnAdd().IsRequired().HasValueGenerator<DateTimeValueGenerator>();
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(Constants.CreatedByMaxLength);
        }
    }
}