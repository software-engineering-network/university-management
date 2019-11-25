using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class CreateApplicationViewModel : ViewModelBase
    {
        private readonly ApplicationDto _application;

        public ApplicantViewModel Applicant { get; }
        public ISelectorViewModel<CollegeViewModel> CollegeSelectorViewModel { get; }
        public string Title => "Create Application";

        public CreateApplicationViewModel(ICollegeReadService collegeReadService)
        {
            _application = new ApplicationDto();

            Applicant = new ApplicantViewModel(_application.Applicant);

            CollegeSelectorViewModel = new CollegeSelectorViewModel(
                _application,
                collegeReadService
            );
        }
    }
}
