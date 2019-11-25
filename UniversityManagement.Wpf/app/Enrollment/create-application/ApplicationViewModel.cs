using System.ComponentModel;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel : ViewModelBase
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
                OnPropertyChanged(nameof(ApplicantName));
                OnPropertyChanged(nameof(ApplicantSurname));
            }
        }

        public string Title => "Create Application";

        public string ApplicantName
        {
            get => _application.Applicant.Name;
            set
            {
                if (_application.Applicant.Name == value)
                    return;

                _application.Applicant.Name = value;
                OnPropertyChanged(nameof(ApplicantName));
            }
        }

        public string ApplicantSurname
        {
            get => _application.Applicant.Surname;
            set
            {
                if (_application.Applicant.Surname == value)
                    return;

                _application.Applicant.Surname = value;
                OnPropertyChanged(nameof(ApplicantSurname));
            }
        }

        public ApplicationViewModel()
        {
            _application = new ApplicationDto();
            Applicant = _application.Applicant;
        }
    }
}
