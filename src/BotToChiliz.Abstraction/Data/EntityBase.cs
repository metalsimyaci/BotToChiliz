namespace BotToChiliz.Abstraction.Data
{
    public abstract class EntityBase<T>:IEntity<T>
    {
        public T Id { get; set; }
    }
}
