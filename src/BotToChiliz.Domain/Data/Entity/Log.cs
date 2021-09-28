using System;
using BotToChiliz.Domain.Data.Abstract;

namespace BotToChiliz.Domain.Data.Entity
{
    public class Log:EntityBase<int>
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}