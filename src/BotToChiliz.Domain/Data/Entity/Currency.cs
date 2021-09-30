using System.Collections.Generic;
using BotToChiliz.Abstraction.Data.Abstract;
using BotToChiliz.Abstraction.Data.Abstract.Audited;


namespace BotToChiliz.Domain.Data.Entity
{
    public class Currency:FullAuditedBase<int>,IActivable
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public ICollection<CurrencyBalance> CurrencyBalances { get; set; }
    }
}