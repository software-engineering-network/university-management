using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel :
        ViewModelBase,
        IApplicantViewModel,
        IApplicationViewModel,
        ICollegeSelectorViewModel,
        IMajorSelectorViewModel,
        IMinorSelectorViewModel
    {
        #region Fields

        private readonly ApplicationDto _application;
        private readonly bool _isSyncing;

        private readonly IEditApplicationService _service;
        private ObservableCollection<CollegeDto> _colleges;
        private ObservableCollection<MinorDto> _minors;
        private ObservableCollection<ProgramDto> _programs;

        #endregion

        #region Construction

        public ApplicationViewModel(IEditApplicationService service)
        {
            _application = new ApplicationDto();
            _service = service;

            PopulateColleges();
            PopulatePrograms();
            PopulateMinors();
        }

        public ApplicationViewModel(
            IEditApplicationService service,
            ApplicationDto application
        ) : this(service)
        {
            _isSyncing = true;

            _application = application;
            SelectedCollege = Colleges.FirstOrDefault(x => x == _application.College);

            _isSyncing = false;
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

        #region IApplicationViewModel Members

        public void SaveApplication()
        {
            _service.CreateApplication(_application);
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
                if (_application.College == value && !_isSyncing)
                    return;

                _application.College = value;
                OnPropertyChanged(nameof(SelectedCollege));

                SelectedCollegeChangedHandler();
            }
        }

        #endregion

        #region IMajorSelectorViewModel Members

        public ObservableCollection<ProgramDto> Programs
        {
            get => _programs;
            private set
            {
                if (_programs == value)
                    return;

                _programs = value;
                OnPropertyChanged(nameof(Programs));
            }
        }

        public ProgramDto SelectedProgram
        {
            get => _application.Program;
            set
            {
                if (_application.Program == value && !_isSyncing)
                    return;

                _application.Program = value;
                OnPropertyChanged(nameof(SelectedProgram));

                SelectedProgramChangedHandler();
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
                if (_application.Minor == value && !_isSyncing)
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

        private void PopulateMinors()
        {
            var minors = _service.FetchMinors();
            Minors = new ObservableCollection<MinorDto>(minors);
        }

        private void PopulatePrograms()
        {
            var programs = _service.FetchPrograms(_application);
            Programs = new ObservableCollection<ProgramDto>(programs);
        }

        private void SelectedCollegeChangedHandler()
        {
            UpdateMajorSelector();

            if (SelectedProgram == null &&
                _programs.Count == 1)
                SelectedProgram = Programs.First();
        }

        private void SelectedProgramChangedHandler()
        {
            if (SelectedProgram == null ||
                SelectedProgram.College == SelectedCollege)
                return;

            SelectedCollege = _colleges.FirstOrDefault(x => x == SelectedProgram.College);
        }

        private void UpdateMajorSelector()
        {
            var previousMajor = SelectedProgram;

            PopulatePrograms();

            if (previousMajor == null ||
                previousMajor.College != SelectedCollege)
                return;

            SelectedProgram = Programs.FirstOrDefault(x => x == previousMajor);
        }
    }
}
