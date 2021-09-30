using System;

namespace BotToChiliz.Abstraction.Data.Audited
{
    public class AuditedBase<T>:EntityBase<T>,IAudited
    {
        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModificationTime { get; set; }
        public string ModifiedBy { get; set; }
    }
}