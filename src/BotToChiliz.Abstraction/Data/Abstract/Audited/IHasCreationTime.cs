using System;

namespace BotToChiliz.Abstraction.Data.Abstract.Audited
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}