namespace UniversityManagement.Domain.Write
{
    public interface IPersonRepository : 
        IReadRepository<Person>,
        IWriteRepository<Person>
    {
        bool Exists(SocialSecurityNumber socialSecurityNumber);
        Person Find(SocialSecurityNumber socialSecurityNumber);
    }
}
