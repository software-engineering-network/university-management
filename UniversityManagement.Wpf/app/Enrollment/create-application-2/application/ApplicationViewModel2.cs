using System;
using System.Collections.Generic;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Domain.Write;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel2 : ViewModelBase
    {
        #region Fields

        private readonly Application _application;
        private readonly ICreateApplicationService _service;

        private IApplicantViewModel2 _applicant;
        private ISelectorViewModel<Minor> _minorSelector;
        private ISelectorViewModel<College> _minorSelectorCollegeFilter;
        private ISelectorViewModel<Program> _programSelector;
        private ISelectorViewModel<College> _programSelectorCollegeFilter;
        private IValidationResult _validationResult;

        #endregion

        #region Properties

        public IApplicantViewModel2 Applicant
        {
            get => _applicant;
            set
            {
                _applicant = value;
                _applicant.NameChangedHandler += ValidateHandler;
                _applicant.SurnameChangedHandler += ValidateHandler;
                _applicant.SocialSecurityNumberChangedHandler += ValidateHandler;
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

        public ISelectorViewModel<College> MinorSelectorCollegeFilter
        {
            get => _minorSelectorCollegeFilter;
            set
            {
                _minorSelectorCollegeFilter = value;
                _minorSelectorCollegeFilter.SelectedItemChanged += SelectedMinorSelectorCollegeFilterChangedHandler;
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

        public ISelectorViewModel<College> ProgramSelectorCollegeFilter
        {
            get => _programSelectorCollegeFilter;
            set
            {
                _programSelectorCollegeFilter = value;
                _programSelectorCollegeFilter.SelectedItemChanged += SelectedProgramSelectorCollegeFilterChangedHandler;
            }
        }

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
                ProgramSelectorCollegeFilter
            };

        #endregion

        #region Construction

        public ApplicationViewModel2(
            ICreateApplicationService service,
            Application application = null
        )
        {
            _service = service;

            _application = application == null
                ? new Application()
                : application;

            Applicant = CreateApplicant(_application);
            MinorSelector = CreateMinorSelector(_application);
            MinorSelectorCollegeFilter = CreateMinorSelectorCollegeFilter(_application);
            ProgramSelector = CreateProgramSelector(_application);
            ProgramSelectorCollegeFilter = CreateProgramSelectorCollegeFilter(_application);

            PopulateCollegeFilters();
            PopulateMinorSelector();
            PopulateProgramSelector();

            Validate();
        }

        #endregion

        private static IApplicantViewModel2 CreateApplicant(Application application)
        {
            if (application.Applicant == null)
                application.Applicant = new Applicant();

            return new ApplicantViewModel(application.Applicant);
        }

        private static ISelectorViewModel<Minor> CreateMinorSelector(Application application)
        {
            if (application.Minor == null)
                application.Minor = new Minor();

            return new SelectorViewModel<Minor>(
                "Minor:",
                application.Minor,
                "MinorId"
            );
        }

        private static ISelectorViewModel<College> CreateMinorSelectorCollegeFilter(Application application)
        {
            return new SelectorViewModel<College>(
                "College:",
                null
            );
        }

        private static ISelectorViewModel<Program> CreateProgramSelector(Application application)
        {
            if (application.Program == null)
                application.Program = new Program();

            return new SelectorViewModel<Program>(
                "Program:",
                application.Program,
                "ProgramId"
            );
        }

        private static ISelectorViewModel<College> CreateProgramSelectorCollegeFilter(Application application)
        {
            if (application.College == null)
                application.College = new College();

            return new SelectorViewModel<College>(
                "College:",
                application.College
            );
        }

        private void PopulateCollegeFilters()
        {
            var colleges = _service.FetchColleges();
            MinorSelectorCollegeFilter.Items = colleges;
            ProgramSelectorCollegeFilter.Items = colleges;
        }

        private void PopulateMinorSelector()
        {
            var college = MinorSelectorCollegeFilter.SelectedItem;

            var minors = college == null || college.Id == 0
                ? _service.FetchMinors()
                : _service.FetchMinors(college.Id);

            MinorSelector.Items = minors;
        }

        private void PopulateProgramSelector()
        {
            var college = ProgramSelectorCollegeFilter.SelectedItem;

            var programs = college == null || college.Id == 0
                ? _service.FetchPrograms()
                : _service.FetchPrograms(college.Id);

            ProgramSelector.Items = programs;
        }

        private void SelectedMinorChangedHandler(object sender, EventArgs args)
        {
            var selectedMinor = ((SelectedItemChangedArgs<Minor>) args).SelectedItem;
            _application.Minor = selectedMinor;

            if (selectedMinor != null && selectedMinor.College != MinorSelectorCollegeFilter.SelectedItem)
                MinorSelectorCollegeFilter.SelectedItem = selectedMinor.College;

            Validate();
        }

        private void SelectedProgramChangedHandler(object sender, EventArgs args)
        {
            var selectedProgram = ((SelectedItemChangedArgs<Program>) args).SelectedItem;
            _application.Program = selectedProgram;

            if (selectedProgram != null && selectedProgram.College != ProgramSelectorCollegeFilter.SelectedItem)
                ProgramSelectorCollegeFilter.SelectedItem = selectedProgram.College;

            Validate();
        }

        private void SelectedMinorSelectorCollegeFilterChangedHandler(object sender, EventArgs args)
        {
            UpdateMinorSelector();
        }

        private void SelectedProgramSelectorCollegeFilterChangedHandler(object sender, EventArgs args)
        {
            UpdateProgramSelector();
        }

        private void UpdateMinorSelector()
        {
            var previousMinor = MinorSelector.SelectedItem;

            PopulateMinorSelector();

            if (previousMinor != null && previousMinor.College == MinorSelectorCollegeFilter.SelectedItem)
                MinorSelector.SelectedItem = previousMinor;
        }

        private void UpdateProgramSelector()
        {
            var previousProgram = ProgramSelector.SelectedItem;

            PopulateProgramSelector();

            if (previousProgram != null && previousProgram.College == ProgramSelectorCollegeFilter.SelectedItem)
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
    }
}
