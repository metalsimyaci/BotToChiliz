namespace BotToChiliz.Abstraction.Data.Audited
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}