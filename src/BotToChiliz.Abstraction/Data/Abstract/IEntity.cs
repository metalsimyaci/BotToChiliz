namespace BotToChiliz.Abstraction.Data.Abstract
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}