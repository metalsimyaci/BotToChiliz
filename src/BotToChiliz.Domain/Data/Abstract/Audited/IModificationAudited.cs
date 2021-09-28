namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public interface IModificationAudited:IHasModificationTime
    {
        string ModifiedBy { get; set; }
    }
}