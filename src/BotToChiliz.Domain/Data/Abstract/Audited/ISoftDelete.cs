namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}