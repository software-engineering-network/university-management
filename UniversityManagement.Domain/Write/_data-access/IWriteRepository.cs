namespace UniversityManagement.Domain.Write
{
    public interface IWriteRepository<T> where T : Entity
    {
        void Create(T obj);
    }
}
