using System;

namespace BotToChiliz.Abstraction.Data.Abstract.Audited
{
    public class CreationAuditedBase<T>: EntityBase<T>,ICreationAudited
    {
        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
