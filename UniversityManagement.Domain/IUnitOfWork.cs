using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Domain
{
    public interface IUnitOfWork
    {
        IApplicationRepository ApplicationRepository { get; }
        IApplicantRepository ApplicantRepository { get; }
        ICollegeRepository CollegeRepository { get; }
        IDisciplineRepository DisciplineRepository { get; }
        IMajorRepository MajorRepository { get; }
        IMinorRepository MinorRepository { get; }
    }
}
