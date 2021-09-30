using System;

namespace BotToChiliz.Abstraction.Data.Audited
{
    public interface IHasModificationTime
    {
        DateTime? ModificationTime { get; set; }
    }
}