namespace Exchange.Core.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        ///     Primary key of the entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}