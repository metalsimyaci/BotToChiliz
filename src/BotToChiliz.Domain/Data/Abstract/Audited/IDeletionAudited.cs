namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public interface IDeletionAudited:ISoftDelete,IHasDeletionTime
    {
        string DeletedBy { get; set; }
    }
}