namespace BotToChiliz.Abstraction.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}