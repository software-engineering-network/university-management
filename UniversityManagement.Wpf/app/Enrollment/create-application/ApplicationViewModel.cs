using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel :
        ViewModelBase,
        IApplicantViewModel,
        IApplicationViewModel,
        ICollegeSelectorViewModel,
        IMinorSelectorViewModel,
        IProgramSelectorViewModel
    {
        #region Fields

        private readonly Application _application;
        private readonly bool _isSyncing;
        private readonly ICreateApplicationService _service;

        private ObservableCollection<College> _colleges;
        private ObservableCollection<Minor> _minors;
        private ObservableCollection<Program> _programs;

        #endregion

        #region Construction

        public ApplicationViewModel(ICreateApplicationService service)
        {
            _application = new Application();
            _service = service;

            PopulateColleges();
            PopulatePrograms();
            PopulateMinors();
        }

        public ApplicationViewModel(
            ICreateApplicationService service,
            Application application
        ) : this(service)
        {
            _isSyncing = true;

            _application = application;
            SelectedCollege = Colleges.FirstOrDefault(x => x == _application.College);
            SelectedProgram = Programs.FirstOrDefault(x => x == _application.Program);
            SelectedMinor = Minors.FirstOrDefault(x => x == _application.Minor);

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

        public ObservableCollection<College> Colleges
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

        public College SelectedCollege
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

        #region IProgramSelectorViewModel Members

        public ObservableCollection<Program> Programs
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

        public Program SelectedProgram
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

        public ObservableCollection<Minor> Minors
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

        public Minor SelectedMinor
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
            Colleges = new ObservableCollection<College>(colleges);
        }

        private void PopulateMinors()
        {
            var minors = _service.FetchMinors();
            Minors = new ObservableCollection<Minor>(minors);
        }

        private void PopulatePrograms()
        {
            var programs = _service.FetchPrograms(_application);
            Programs = new ObservableCollection<Program>(programs);
        }

        private void SelectedCollegeChangedHandler()
        {
            UpdateProgramSelector();

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

        private void UpdateProgramSelector()
        {
            var previousProgram = SelectedProgram;

            PopulatePrograms();

            if (previousProgram == null ||
                previousProgram.College != SelectedCollege)
                return;

            SelectedProgram = Programs.FirstOrDefault(x => x == previousProgram);
        }
    }
}
