using System;

namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public interface IHasModificationTime
    {
        DateTime? ModificationTime { get; set; }
    }
}