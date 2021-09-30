namespace BotToChiliz.Abstraction.Data.Audited
{
    public interface IModificationAudited:IHasModificationTime
    {
        string ModifiedBy { get; set; }
    }
}