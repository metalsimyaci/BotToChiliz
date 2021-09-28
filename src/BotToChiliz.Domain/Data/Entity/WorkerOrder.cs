using System;
using BotToChiliz.Domain.Data.Abstract;
using BotToChiliz.Domain.Data.Enumeration;

namespace BotToChiliz.Domain.Data.Entity
{
    public class WorkerOrder : EntityBase<int>
    {
        public int WorkerId { get; set; }
        public string Key { get; set; }
        public OrderTypes Type { get; set; }
        public OrderStatuses Status { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }

        public Worker Worker { get; set; }
    }
}