namespace BotToChiliz.Abstraction.Data.Abstract.Audited
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}