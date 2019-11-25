using System;
using System.Collections.ObjectModel;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel :
        ViewModelBase,
        IApplicantViewModel,
        ICollegeSelectorViewModel
    {
        #region Fields

        private readonly ApplicationDto _application;
        private ObservableCollection<CollegeDto> _colleges;

        #endregion

        #region Construction

        public ApplicationViewModel(ICollegeReadService collegeReadService)
        {
            _application = new ApplicationDto();

            Colleges = new ObservableCollection<CollegeDto>(
                collegeReadService.FetchColleges()
            );
        }

        #endregion

        #region IApplicantViewModel Members

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

        #endregion

        #region ICollegeSelectorViewModel Members

        public ObservableCollection<CollegeDto> Colleges
        {
            get => _colleges;
            set
            {
                if (_colleges == value)
                    return;

                _colleges = value;
                OnPropertyChanged(nameof(Colleges));
            }
        }

        public CollegeDto SelectedCollege
        {
            get => _application.College;
            set
            {
                if (_application.College == value)
                    return;

                _application.College = value;
                OnPropertyChanged(nameof(SelectedCollege));
            }
        }

        #endregion
    }
}
