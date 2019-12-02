using System;
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
        private IValidationResult _validationResult;

        #endregion

        #region Properties

        public IApplicantViewModel2 Applicant
        {
            get => _applicant;
            set
            {
                _applicant = value;
                _applicant.NameChangedHandler += Validate;
                _applicant.SurnameChangedHandler += Validate;
            }
        }

        private IValidationResult ValidationResult
        {
            set
            {
                _validationResult = value;

                Applicant.ValidationResult = _validationResult;
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

            Validate();
        }

        #endregion

        private static IApplicantViewModel2 CreateApplicantViewModel(Application application)
        {
            if (application.Applicant == null)
                application.Applicant = new Applicant();

            return new ApplicantViewModel(application.Applicant);
        }

        private void Validate()
        {
            ValidationResult = _service.Validate(_application);
        }

        private void Validate(object sender, EventArgs args)
        {
            Validate();
        }
    }
}
