using System;

namespace BotToChiliz.Abstraction.Data.Abstract.Audited
{
    public interface IHasModificationTime
    {
        DateTime? ModificationTime { get; set; }
    }
}