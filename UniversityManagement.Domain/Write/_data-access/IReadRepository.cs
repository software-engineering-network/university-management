namespace UniversityManagement.Domain.Write
{
    public interface IReadRepository<T> where T : Entity
    {
        T Find(long id);
    }
}
