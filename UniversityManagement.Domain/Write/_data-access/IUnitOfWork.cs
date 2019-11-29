using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Domain.Write
{
    public interface IUnitOfWork
    {
        #region Properties

        IApplicationRepository ApplicationRepository { get; }
        IApplicantRepository ApplicantRepository { get; }
        ICollegeRepository CollegeRepository { get; }
        IProgramRepository ProgramRepository { get; }

        #endregion

        void Commit();
    }
}
