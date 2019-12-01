namespace UniversityManagement.Domain.Write.Enrollment
{
    public interface IApplicantRepository : 
        IReadRepository<Applicant>,
        IWriteRepository<Applicant>
    {
        Applicant Find(string socialSecurityNumber);
    }
}
