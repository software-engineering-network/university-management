using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Domain.Read
{
    public interface IUnitOfWork
    {
        #region Properties

        IApplicationRepository ApplicationRepository { get; }
        IApplicantRepository ApplicantRepository { get; }
        ICollegeRepository CollegeRepository { get; }
        IDisciplineRepository DisciplineRepository { get; }
        IMajorRepository MajorRepository { get; }
        IMinorRepository MinorRepository { get; }

        #endregion
    }
}
