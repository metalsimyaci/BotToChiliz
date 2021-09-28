using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Utils
{
    public class DateTimeValueGenerator : ValueGenerator<DateTime>
    {
        public override DateTime Next(EntityEntry entry)
        {
            if (entry == null)
                throw new ArgumentException(nameof(entry));
            return DateTime.Now;
        }

        public override bool GeneratesTemporaryValues => false;
    }
}
