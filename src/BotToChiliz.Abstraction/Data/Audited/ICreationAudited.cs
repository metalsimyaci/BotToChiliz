namespace BotToChiliz.Abstraction.Data.Audited
{
    public interface ICreationAudited:IHasCreationTime
    {
        string CreatedBy { get; set; }
    }
}