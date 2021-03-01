namespace Lekadex.Database
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        void AddNew(Entity entity);

        bool Delete(Entity entity);
    }
}
