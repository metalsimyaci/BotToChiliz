using BotToChiliz.Abstraction.DataAccess.EntityFramework.Abstract.Configuration;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.Data.Enumeration;
using BotToChiliz.Domain.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Configuration
{
    internal class WorkerConfiguration:FullAuditedConfigurationBase<Worker>,
        IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Workers", Constants.SCHEME_NAME);
            builder.HasKey(k => k.Id);

            builder.Property(p => p.CurrencyId).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(Constants.WORKER_NAME_MAX_LENGTH);
            builder.Property(p => p.Type).IsRequired().HasConversion<EnumToStringConverter<WorkerType>>();
            builder.Property(p => p.Status).IsRequired().HasConversion<EnumToStringConverter<WorkerStatuses>>();
            builder.Property(p => p.Quantity).IsRequired();
            
            builder.Property(p => p.Timeout).IsRequired();
            builder.Property(p => p.MinQuantityLimit).IsRequired();
            builder.Property(p => p.MaxQuantityLimit).IsRequired();
            builder.Property(p => p.PriceDifferentLimit).IsRequired();
            builder.Property(p => p.RateLimit).IsRequired();
            
            base.ConfigureAudit(builder);

            //Index
            builder.HasIndex(p =>new{p.CurrencyId,p.Name,p.Type}, "IX_Worker_CurrencyIdNameType");

            //Relations
            builder.HasOne(h => h.Currency)
                .WithMany(m => m.Workers)
                .HasForeignKey(k => k.CurrencyId);
        }
    }
}