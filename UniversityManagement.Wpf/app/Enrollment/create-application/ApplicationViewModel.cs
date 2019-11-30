using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Domain.Write;
using UniversityManagement.Services.Enrollment;
using Application = UniversityManagement.Domain.Read.Enrollment.Application;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using Minor = UniversityManagement.Domain.Read.Enrollment.Minor;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;

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

        private readonly bool _isSyncing;
        private readonly ICreateApplicationService _service;

        private Application _application;
        private IValidationResult _validationResult;

        private ObservableCollection<College> _colleges;
        private ObservableCollection<Minor> _minors;
        private ObservableCollection<Program> _programs;

        #endregion

        #region Properties

        private Application Application
        {
            set
            {
                _application = value;
                Validate();
            }
        }

        private IValidationResult ValidationResult
        {
            set
            {
                _validationResult = value;

                OnPropertyChanged(nameof(IsValid));
                OnPropertyChanged(nameof(ApplicantNameValidationMessage));
                OnPropertyChanged(nameof(ApplicantSurnameValidationMessage));
                OnPropertyChanged(nameof(SelectedProgramValidationMessage));
            }
        }

        #endregion

        #region Construction

        public ApplicationViewModel(ICreateApplicationService service)
        {
            _service = service;

            Application = new Application();

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

            Application = application;

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

                Validate();
            }
        }

        public string ApplicantNameValidationMessage => _validationResult.GetMessage(nameof(ApplicantName));

        public string ApplicantSurname
        {
            get => _application.Applicant.Surname;
            set
            {
                if (ApplicantSurname == value)
                    return;

                _application.Applicant.Surname = value;
                OnPropertyChanged(nameof(ApplicantSurname));

                Validate();
            }
        }

        public string ApplicantSurnameValidationMessage => _validationResult.GetMessage(nameof(ApplicantSurname));

        #endregion

        #region IApplicationViewModel Members

        public bool IsValid => _validationResult.IsValid;

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
                Validate();
            }
        }

        public string SelectedProgramValidationMessage => _validationResult.GetMessage("ProgramId");

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
            var programs = _application.College == null
                ? _service.FetchPrograms()
                : _service.FetchPrograms(_application.College.Id);

            Programs = new ObservableCollection<Program>(programs);
        }

        private void SelectedCollegeChangedHandler()
        {
            UpdateProgramSelector();

            if (SelectedProgram == null && _programs.Count == 1)
                SelectedProgram = Programs.First();
        }

        private void SelectedProgramChangedHandler()
        {
            if (SelectedProgram == null || SelectedProgram.College == SelectedCollege)
                return;

            SelectedCollege = _colleges.FirstOrDefault(x => x == SelectedProgram.College);
        }

        private void UpdateProgramSelector()
        {
            var previousProgram = SelectedProgram;

            PopulatePrograms();

            if (previousProgram == null || previousProgram.College != SelectedCollege)
                return;

            SelectedProgram = Programs.FirstOrDefault(x => x == previousProgram);
        }

        private void Validate()
        {
            ValidationResult = _service.Validate(_application);
        }
    }
}
