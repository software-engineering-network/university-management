using System.Collections.Generic;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class ApplicationProcessor : IApplicationProcessor
    {
        #region Fields

        private readonly IPersonService _personService;
        private readonly CreateApplicationValidator _createApplicationValidator;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public ApplicationProcessor(
            IUnitOfWork unitOfWork,
            CreateApplicationValidator createApplicationValidator
        )
        {
            _createApplicationValidator = createApplicationValidator;
            _unitOfWork = unitOfWork;
            _personService = new PersonService(_unitOfWork);
        }

        #endregion

        #region IApplicationProcessor Members

        public void CreateApplication(CreateApplication command)
        {
            if (!Validate(command).IsValid)
                return;

            var application = BuildApplication(command);

            if (application.Exists)
                _unitOfWork.ApplicationRepository.Update(application);
            else
                _unitOfWork.ApplicationRepository.Create(application);

            _unitOfWork.Commit();
        }

        public void CreateApplications(IEnumerable<CreateApplication> commands)
        {
            foreach (var command in commands)
                CreateApplication(command);
        }

        public IValidationResult Validate(CreateApplication command)
        {
            var fluentValidationResult = _createApplicationValidator.Validate(command);
            var validationResult = new ValidationResult(fluentValidationResult);
            return validationResult;
        }

        #endregion

        private Application BuildApplication(CreateApplication command)
        {
            var applicant = GetApplicant(command);
            UpdateApplicant(applicant, command);

            var program = _unitOfWork.ProgramRepository.Find(command.ProgramId);
            var minor = _unitOfWork.MinorRepository.Find(command.MinorId);

            var application = new Application(
                applicant,
                program,
                minor,
                command.ApplicationId
            );

            return application;
        }

        private void CreateApplicant(CreateApplication command)
        {
            var applicant = new Person(
                command.ApplicantName,
                command.ApplicantSurname,
                command.ApplicantSocialSecurityNumber
            );

            _personService.Create(applicant);
            _unitOfWork.Commit();
        }

        private Person GetApplicant(CreateApplication command)
        {
            // an associated applicant exists
            if (command.ApplicantId != 0)
                return _unitOfWork.PersonRepository.Find(command.ApplicantId);

            // applicant might exist
            var applicant = _unitOfWork.PersonRepository.Find(new SocialSecurityNumber(command.ApplicantSocialSecurityNumber));
            if (applicant != null)
                return applicant;
            
            // applicant does not exist
            CreateApplicant(command);
            return _unitOfWork.PersonRepository.Find(new SocialSecurityNumber(command.ApplicantSocialSecurityNumber));
        }

        private void UpdateApplicant(Person applicant, CreateApplication command)
        {
            applicant.UpdateName(command.ApplicantName);
            applicant.UpdateSurname(command.ApplicantSurname);
            applicant.UpdateSocialSecurityNumber(command.ApplicantSocialSecurityNumber);

            _personService.Update(applicant);
        }
    }
}
