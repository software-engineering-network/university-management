using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel :
        ViewModelBase,
        IApplicantViewModel,
        ICollegeSelectorViewModel,
        IMajorSelectorViewModel,
        IMinorSelectorViewModel
    {
        #region Fields

        private readonly IEditApplicationService _service;

        private ApplicationDto _application;
        private ObservableCollection<CollegeDto> _colleges;
        private ObservableCollection<MajorDto> _majors;
        private ObservableCollection<MinorDto> _minors;

        #endregion

        private ApplicationDto Application
        {
            get => _application;
            set
            {
                if (_application == value)
                    return;

                _application = value;
            }
        }

        #region Construction

        public ApplicationViewModel(IEditApplicationService service)
        {
            _application = new ApplicationDto();
            _service = service;

            PopulateColleges();
            PopulateMajors();
            PopulateMinors();
        }

        public ApplicationViewModel(
            IEditApplicationService service,
            ApplicationDto application
        ) : this(service)
        {
            Application = application;
        }

        #endregion

        #region IApplicantViewModel Members

        public string ApplicantName
        {
            get => _application.Applicant.Name;
            set
            {
                if (ApplicantName == value)
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
                if (ApplicantSurname == value)
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
                if (_application.College == value)
                    return;

                _application.College = value;
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
            //get => Majors.FirstOrDefault(x => x == _application.Major);
            set
            {
                if (_application.Major == value)
                    return;

                _application.Major = value;
                OnPropertyChanged(nameof(SelectedMajor));

                SelectedMajorChangedHandler();
            }
        }

        #endregion

        #region IMinorSelectorViewModel Members

        public ObservableCollection<MinorDto> Minors
        {
            get => _minors;
            private set
            {
                if (_minors == value)
                    return;

                _minors = value;
                OnPropertyChanged(nameof(Minors));
            }
        }
    
        public MinorDto SelectedMinor
        {
            get => _application.Minor;
            set
            {
                if (_application.Minor == value)
                    return;

                _application.Minor = value;
                OnPropertyChanged(nameof(SelectedMinor));
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

        private void PopulateMinors()
        {
            var minors = _service.FetchMinors();
            Minors = new ObservableCollection<MinorDto>(minors);
        }

        private void SelectedCollegeChangedHandler()
        {
            UpdateMajorSelector();

            if ((SelectedMajor == null || SelectedMajor.Id == 0)
                && _majors.Count == 1)
                SelectedMajor = Majors.First();
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
