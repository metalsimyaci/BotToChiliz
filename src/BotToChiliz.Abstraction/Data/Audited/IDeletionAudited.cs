namespace BotToChiliz.Abstraction.Data.Audited
{
    public interface IDeletionAudited:ISoftDelete,IHasDeletionTime
    {
        string DeletedBy { get; set; }
    }
}