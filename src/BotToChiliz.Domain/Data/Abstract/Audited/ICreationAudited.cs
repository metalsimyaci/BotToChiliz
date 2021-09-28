namespace BotToChiliz.Domain.Data.Abstract.Audited
{
    public interface ICreationAudited:IHasCreationTime
    {
        string CreatedBy { get; set; }
    }
}