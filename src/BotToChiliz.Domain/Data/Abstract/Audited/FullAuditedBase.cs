using System;

namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public abstract class FullAuditedBase<T>:EntityBase<T>,IFullAudited
    {
        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModificationTime { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
