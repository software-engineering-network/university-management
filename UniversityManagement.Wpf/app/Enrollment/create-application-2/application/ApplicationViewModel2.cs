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
            }
        }

        public ISelectorViewModel<College> ProgramSelectorCollegeFilter
        {
            get => _programSelectorCollegeFilter;
            set
            {
                _programSelectorCollegeFilter = value;
                _programSelectorCollegeFilter.SelectedItemChanged += SelectedProgramChangedHandler;
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
                ProgramSelector
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
            ProgramSelector = CreateProgramSelector(_application);
            ProgramSelectorCollegeFilter = CreateProgramSelectorCollegeFilter(_application);

            Validate();
        }

        #endregion

        private static IApplicantViewModel2 CreateApplicant(Application application)
        {
            if (application.Applicant == null)
                application.Applicant = new Applicant();

            return new ApplicantViewModel(application.Applicant);
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

        private void SelectedProgramChangedHandler(object sender, EventArgs args)
        {
            Validate();
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
