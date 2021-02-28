namespace Lekadex.Database
{
    public interface Irepository<Entity> where Entity : BaseEntity
    {
        void AddNew(Entity doctor);

        bool Delete(Entity doctor);
    }
}
