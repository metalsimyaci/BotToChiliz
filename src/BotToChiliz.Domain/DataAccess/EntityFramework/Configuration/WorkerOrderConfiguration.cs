using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.Data.Enumeration;
using BotToChiliz.Domain.DataAccess.EntityFramework.Abstract.Configuration;
using BotToChiliz.Domain.DataAccess.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Configuration
{
    internal class WorkerOrderConfiguration:CreationAuditedConfigurationBase<WorkerOrder>,
        IEntityTypeConfiguration<WorkerOrder>
    {
        public void Configure(EntityTypeBuilder<WorkerOrder> builder)
        {
            builder.ToTable("WorkerOrders", Constants.SCHEME_NAME);
            builder.HasKey(k => k.Id);

            builder.Property(p => p.WorkerId).IsRequired();
            builder.Property(p => p.Key).IsRequired().HasMaxLength(Constants.WORKER_ORDER_KEY_LENGTH);
            builder.Property(p => p.Type).IsRequired().HasConversion<EnumToStringConverter<OrderTypes>>();
            builder.Property(p => p.Status).IsRequired().HasConversion<EnumToStringConverter<OrderStatuses>>();
            builder.Property(p => p.Quantity).IsRequired();

            base.ConfigureAudit(builder);

            //Index
            builder.HasIndex(p => p.Key, "IX_WORKER_ORDER_KEY");
            
            //Relation
            builder.HasOne(o => o.Worker)
                .WithMany(m => m.WorkerOrders)
                .HasForeignKey(k => k.WorkerId);
        }
    }
}