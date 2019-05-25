namespace StudentApp.Data.Data.Entities
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}