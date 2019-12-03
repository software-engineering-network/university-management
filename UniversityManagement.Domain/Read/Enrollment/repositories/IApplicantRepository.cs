namespace UniversityManagement.Domain.Read.Enrollment
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Applicant Find(string socialSecurityNumber);
    }
}
