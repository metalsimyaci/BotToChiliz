using System.Collections.Generic;
using BotToChiliz.Domain.Data.Abstract.Audited;
using BotToChiliz.Domain.Data.Enumeration;

namespace BotToChiliz.Domain.Data.Entity
{
    public class Worker:FullAuditedBase<int>
    {
        public int CurrencyId { get; set; }

        public string WorkerName { get; set; }
        public WorkerType Type { get; set; }
        public WorkerStatuses Status { get; set; }

        public double Quantity { get; set; }
        
        public int Timeout { get; set; }
        public int MinQuantityLimit { get; set; }
        public int MaxQuantityLimit { get; set; }
        public double PriceDifferentLimit { get; set; }
        public double LevelReductionLimit { get; set; }
        public double RateLimit { get; set; }

        public Currency Currency { get; set; }
        public ICollection<WorkerOrder> WorkerOrders { get; set; }
    }
}
