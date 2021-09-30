namespace BotToChiliz.Abstraction.Data.Abstract.Audited
{
    public interface IDeletionAudited:ISoftDelete,IHasDeletionTime
    {
        string DeletedBy { get; set; }
    }
}