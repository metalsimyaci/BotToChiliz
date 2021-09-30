using BotToChiliz.Abstraction.Data.Abstract.Audited;
using BotToChiliz.Domain.Data.Enumeration;

namespace BotToChiliz.Domain.Data.Entity
{
    public class WorkerOrder : CreationAuditedBase<int>
    {
        public int WorkerId { get; set; }
        public string Key { get; set; }
        public OrderTypes Type { get; set; }
        public OrderStatuses Status { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

        public Worker Worker { get; set; }
    }
}