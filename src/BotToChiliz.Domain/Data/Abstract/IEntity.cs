namespace BotToChiliz.Domain.Data.Abstract
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}