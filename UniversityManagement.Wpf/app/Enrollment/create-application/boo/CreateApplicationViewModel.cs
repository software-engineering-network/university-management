using UniversityManagement.Domain.Enrollment;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class CreateApplicationViewModel : ViewModelBase
    {
        private readonly ApplicationDto _application;

        public ApplicantDto Applicant
        {
            get => _application.Applicant;
            set
            {
                if (_application.Applicant == value)
                    return;

                _application.Applicant = value;
                OnPropertyChanged(nameof(Applicant));
            }
        }

        public ISelectorViewModel<CollegeViewModel> CollegeSelectorViewModel { get; }
        public string Title => "Create Application";

        public CreateApplicationViewModel(ICollegeReadService collegeReadService)
        {
            _application = new ApplicationDto();

            CollegeSelectorViewModel = new CollegeSelectorViewModel(
                _application,
                collegeReadService
            );
        }
    }
}
