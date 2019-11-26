using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel :
        ViewModelBase,
        IApplicantViewModel,
        ICollegeSelectorViewModel,
        IMajorSelectorViewModel
    {
        #region Fields

        private readonly ApplicationDto _application;
        private readonly IEditApplicationService _service;
        private ObservableCollection<CollegeDto> _colleges;
        private ObservableCollection<MajorDto> _majors;

        #endregion

        #region Construction

        public ApplicationViewModel(IEditApplicationService service)
        {
            _application = new ApplicationDto();
            _service = service;

            PopulateColleges();
            PopulateMajors();
        }

        #endregion

        #region IApplicantViewModel Members

        public string ApplicantName
        {
            get => _application.Applicant.Name;
            set
            {
                if (!_service.SetApplicantName(_application, value))
                    return;

                OnPropertyChanged(nameof(ApplicantName));
            }
        }

        public string ApplicantSurname
        {
            get => _application.Applicant.Surname;
            set
            {
                if (!_service.SetApplicantSurname(_application, value))
                    return;

                OnPropertyChanged(nameof(ApplicantSurname));
            }
        }

        #endregion

        #region ICollegeSelectorViewModel Members

        public ObservableCollection<CollegeDto> Colleges
        {
            get => _colleges;
            private set
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
                if (!_service.SetCollege(_application, value))
                    return;

                OnPropertyChanged(nameof(SelectedCollege));

                SelectedCollegeChangedHandler();
            }
        }

        #endregion

        #region IMajorSelectorViewModel Members

        public ObservableCollection<MajorDto> Majors
        {
            get => _majors;
            private set
            {
                if (_majors == value)
                    return;

                _majors = value;
                OnPropertyChanged(nameof(Majors));
            }
        }

        public MajorDto SelectedMajor
        {
            get => _application.Major;
            set
            {
                if (!_service.SetMajor(_application, value))
                    return;

                OnPropertyChanged(nameof(SelectedMajor));

                SelectedMajorChangedHandler();
            }
        }

        #endregion

        private void PopulateColleges()
        {
            var colleges = _service.FetchColleges();
            Colleges = new ObservableCollection<CollegeDto>(colleges);
        }

        private void PopulateMajors()
        {
            var majors = _service.FetchMajors(_application);
            Majors = new ObservableCollection<MajorDto>(majors);
        }

        private void SelectedCollegeChangedHandler()
        {
            if (SelectedCollege != SelectedMajor.College)
                UpdateMajorSelector();
        }

        private void SelectedMajorChangedHandler()
        {
            if (SelectedMajor == null ||
                SelectedMajor.College == SelectedCollege)
                return;

            SelectedCollege = _colleges.First(x => x == SelectedMajor.College);
        }

        private void UpdateMajorSelector()
        {
            var previousMajor = SelectedMajor;

            PopulateMajors();

            if (previousMajor == null ||
                previousMajor.Id == 0 ||
                previousMajor.College != SelectedCollege)
                return;

            SelectedMajor = Majors.First(x => x == previousMajor);
        }
    }
}
