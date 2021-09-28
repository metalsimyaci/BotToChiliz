using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Configuration
{
    internal class LogConfiguration:IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs", Constants.SCHEME_NAME);
            builder.HasKey(k => k.Id);

            //Configuration
            builder.Property(p => p.Properties).IsRequired(false);
            builder.Property(p => p.Level).IsRequired(false).HasMaxLength(Constants.LOG_LEVEL_MAX_LENGTH);
            builder.Property(p => p.Message).IsRequired(false);
            builder.Property(p => p.Exception).IsRequired(false);
            builder.Property(p => p.TimeStamp).IsRequired();
        }
    }
}