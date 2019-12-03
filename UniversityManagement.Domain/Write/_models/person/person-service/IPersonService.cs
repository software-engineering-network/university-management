namespace UniversityManagement.Domain.Write
{
    public interface IPersonService
    {
        void Create(Person person);
        void Update(Person person);
    }
}
