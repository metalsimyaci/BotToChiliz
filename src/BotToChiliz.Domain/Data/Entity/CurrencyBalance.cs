using BotToChiliz.Domain.Data.Abstract.Audited;
using BotToChiliz.Domain.Data.Enumeration;

namespace BotToChiliz.Domain.Data.Entity
{
    public class CurrencyBalance: CreationAuditedBase<int>
    {
        public int CurrencyId { get; set; }
        public BalanceTypes Type { get; set; }
        public double Balance { get; set; }

        public Currency Currency { get; set; }
    }
}
