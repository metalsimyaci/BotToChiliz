using System;

namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}