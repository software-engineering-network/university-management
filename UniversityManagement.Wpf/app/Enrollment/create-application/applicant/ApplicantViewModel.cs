using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicantViewModel : ViewModelBase
    {
        #region Fields

        private ApplicantDto _applicant;

        private ApplicantDto Applicant
        {
            get => _applicant;
            set
            {
                if (_applicant == value)
                    return;

                _applicant = value;

                OnPropertyChanged(nameof(Applicant));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Surname));
            }
        }

        #endregion

        #region Properties

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

        #endregion

        #region Construction

        public ApplicantViewModel(ApplicantDto applicant)
        {
            Applicant = applicant;
        }

        #endregion
    }
}
