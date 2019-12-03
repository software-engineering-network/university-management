using System;
using System.Collections.Generic;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Domain.Write;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel :
        ViewModelBase,
        IApplicationViewModel
    {
        #region Fields

        private readonly Application _application;
        private readonly ICreateApplicationService _service;

        private IApplicantViewModel _applicant;
        private ISelectorViewModel<College> _minorCollegeFilter;
        private ISelectorViewModel<Minor> _minorSelector;
        private ISelectorViewModel<College> _programCollegeFilter;
        private ISelectorViewModel<Program> _programSelector;
        private IValidationResult _validationResult;

        #endregion

        #region Properties

        private IValidationResult ValidationResult
        {
            set
            {
                _validationResult = value;

                foreach (var vm in ValidationResultViewModels)
                    vm.ValidationResult = _validationResult;
            }
        }

        private IEnumerable<IValidationResultViewModel> ValidationResultViewModels =>
            new List<IValidationResultViewModel>
            {
                Applicant,
                MinorSelector,
                ProgramSelector,
                ProgramCollegeFilter
            };

        #endregion

        #region Construction

        public ApplicationViewModel(
            ICreateApplicationService service,
            Application application = null
        )
        {
            _service = service;

            _application = application == null
                ? new Application()
                : application;

            Applicant = CreateApplicant(_application);
            MinorSelector = new SelectorViewModel<Minor>(_application.Minor, "Minor", "MinorId");
            MinorCollegeFilter = new SelectorViewModel<College>(labelText: "College");
            ProgramSelector = new SelectorViewModel<Program>(_application.Program, "Program", "ProgramId");
            ProgramCollegeFilter = new SelectorViewModel<College>(_application.College, "College");

            PopulateCollegeFilters();
            PopulateMinorSelector();
            PopulateProgramSelector();

            Validate();
        }

        #endregion

        #region Methods

        private static IApplicantViewModel CreateApplicant(Application application)
        {
            if (application.Applicant == null)
                application.Applicant = new Applicant();

            return new ApplicantViewModel(application.Applicant);
        }

        private void PopulateCollegeFilters()
        {
            var colleges = _service.FetchColleges();
            MinorCollegeFilter.Items = colleges;
            ProgramCollegeFilter.Items = colleges;
        }

        private void PopulateMinorSelector()
        {
            var college = MinorCollegeFilter.SelectedItem;

            var minors = college == null
                ? _service.FetchMinors()
                : _service.FetchMinors(college.Id);

            MinorSelector.Items = minors;
        }

        private void PopulateProgramSelector()
        {
            var college = ProgramCollegeFilter.SelectedItem;

            var programs = college == null
                ? _service.FetchPrograms()
                : _service.FetchPrograms(college.Id);

            ProgramSelector.Items = programs;
        }

        private void SelectedMinorChangedHandler(object sender, SelectedItemChangedArgs<Minor> args)
        {
            var selectedMinor = args.SelectedItem;
            _application.Minor = selectedMinor;

            if (selectedMinor != null && selectedMinor.College != MinorCollegeFilter.SelectedItem)
                MinorCollegeFilter.SelectedItem = selectedMinor.College;

            Validate();
        }
        
        private void SelectedProgramChangedHandler(object sender, SelectedItemChangedArgs<Program> args)
        {
            var selectedProgram = args.SelectedItem;
            _application.Program = selectedProgram;

            if (selectedProgram != null && selectedProgram.College != ProgramCollegeFilter.SelectedItem)
                ProgramCollegeFilter.SelectedItem = selectedProgram.College;

            Validate();
        }

        private void SelectedMinorCollegeFilterChangedHandler(object sender, SelectedItemChangedArgs<Minor> args)
        {
            UpdateMinorSelector();
        }

        private void SelectedProgramCollegeFilterChangedHandler(object sender, SelectedItemChangedArgs<College> args)
        {
            UpdateProgramSelector();
        }

        private void UpdateMinorSelector()
        {
            var previousMinor = MinorSelector.SelectedItem;

            PopulateMinorSelector();

            if (previousMinor != null && previousMinor.College == MinorCollegeFilter.SelectedItem)
                MinorSelector.SelectedItem = previousMinor;
        }

        private void UpdateProgramSelector()
        {
            var previousProgram = ProgramSelector.SelectedItem;

            PopulateProgramSelector();

            if (previousProgram != null && previousProgram.College == ProgramCollegeFilter.SelectedItem)
                ProgramSelector.SelectedItem = previousProgram;
        }

        private void Validate()
        {
            ValidationResult = _service.Validate(_application);
        }

        private void ValidateHandler(object sender, EventArgs args)
        {
            Validate();
        }

        #endregion

        #region IApplicationViewModel

        public IApplicantViewModel Applicant
        {
            get => _applicant;
            set
            {
                _applicant = value;
                _applicant.NameChanged += ValidateHandler;
                _applicant.SurnameChanged += ValidateHandler;
                _applicant.SocialSecurityNumberChanged += ValidateHandler;
            }
        }

        public ISelectorViewModel<College> MinorCollegeFilter
        {
            get => _minorCollegeFilter;
            set
            {
                _minorCollegeFilter = value;
                _minorCollegeFilter.SelectedItemChanged += SelectedMinorCollegeFilterChangedHandler;
            }
        }

        public ISelectorViewModel<Minor> MinorSelector
        {
            get => _minorSelector;
            set
            {
                _minorSelector = value;
                _minorSelector.SelectedItemChanged += SelectedMinorChangedHandler;
            }
        }

        public ISelectorViewModel<College> ProgramCollegeFilter
        {
            get => _programCollegeFilter;
            set
            {
                _programCollegeFilter = value;
                _programCollegeFilter.SelectedItemChanged += SelectedProgramCollegeFilterChangedHandler;
            }
        }

        public ISelectorViewModel<Program> ProgramSelector
        {
            get => _programSelector;
            set
            {
                _programSelector = value;
                _programSelector.SelectedItemChanged += SelectedProgramChangedHandler;
            }
        }

        #endregion
    }
}
