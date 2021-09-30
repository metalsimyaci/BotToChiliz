namespace BotToChiliz.Abstraction.Data.Abstract.Audited
{
    public interface ICreationAudited:IHasCreationTime
    {
        string CreatedBy { get; set; }
    }
}