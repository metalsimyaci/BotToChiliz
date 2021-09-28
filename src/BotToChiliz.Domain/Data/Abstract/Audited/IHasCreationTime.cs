using System;

namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}