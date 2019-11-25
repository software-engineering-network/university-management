using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicantViewModel : ViewModelBase
    {
        private readonly ApplicantDto _applicant;

        public string Name
        {
            get => _applicant.Name;
            set
            {
                if (_applicant.Name == value)
                    return;

                _applicant.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _applicant.Surname;
            set
            {
                if (_applicant.Surname == value)
                    return;

                _applicant.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public ApplicantViewModel(ApplicantDto applicant)
        {
            _applicant = applicant;
        }
    }
}
