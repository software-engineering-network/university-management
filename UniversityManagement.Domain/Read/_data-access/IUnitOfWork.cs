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
        IMinorRepository MinorRepository { get; }
        IProgramRepository ProgramRepository { get; }

        #endregion
    }
}
