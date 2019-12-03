using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IApplicationViewModel
    {
        #region Properties

        IApplicantViewModel Applicant { get; set; }
        ISelectorViewModel<College> MinorCollegeFilter { get; set; }
        ISelectorViewModel<Minor> MinorSelector { get; set; }
        ISelectorViewModel<College> ProgramCollegeFilter { get; set; }
        ISelectorViewModel<Program> ProgramSelector { get; set; }

        #endregion
    }
}
