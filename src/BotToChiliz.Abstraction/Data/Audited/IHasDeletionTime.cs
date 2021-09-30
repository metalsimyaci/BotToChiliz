using System;

namespace BotToChiliz.Abstraction.Data.Audited
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}