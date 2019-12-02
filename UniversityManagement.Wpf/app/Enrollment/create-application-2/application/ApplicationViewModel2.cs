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
        private IProgramViewModel _program;
        private IValidationResult _validationResult;

        private IEnumerable<IValidationResultViewModel> ValidationResultViewModels =>
            new List<IValidationResultViewModel>
            {
                Applicant,
                Program
            };

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

        public IProgramViewModel Program
        {
            get => _program;
            set
            {
                _program = value;
                _program.SelectedProgramChanged += SelectedProgramChangedHandler;
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

            Applicant = CreateApplicantViewModel(_application);
            Program = CreateProgramViewModel(_application);

            Validate();
        }

        #endregion

        private static IApplicantViewModel2 CreateApplicantViewModel(Application application)
        {
            if (application.Applicant == null)
                application.Applicant = new Applicant();

            return new ApplicantViewModel(application.Applicant);
        }

        private static IProgramViewModel CreateProgramViewModel(Application application)
        {
            if (application.Program == null)
                application.Program = new Program();

            return new ProgramViewModel(application.Program);
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
