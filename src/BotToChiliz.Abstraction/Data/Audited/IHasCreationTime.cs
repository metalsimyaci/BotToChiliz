using System;

namespace BotToChiliz.Abstraction.Data.Audited
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}