using UniversityManagement.Domain.Enrollment.Read;
using UniversityManagement.Domain.Read;

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
