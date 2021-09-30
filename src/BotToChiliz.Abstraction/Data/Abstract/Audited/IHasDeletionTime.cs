using System;

namespace BotToChiliz.Abstraction.Data.Abstract.Audited
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}