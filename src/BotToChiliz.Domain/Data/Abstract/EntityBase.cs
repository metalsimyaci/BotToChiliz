namespace BotToChiliz.Domain.Data.Abstract
{
    public abstract class EntityBase<T>:IEntity<T>
    {
        public T Id { get; set; }
    }
}
