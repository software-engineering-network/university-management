using System.Collections.Generic;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class ApplicationProcessor : IApplicationProcessor
    {
        #region Fields

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
        }

        #endregion

        #region IApplicationProcessor Members

        public void CreateApplication(CreateApplication command)
        {
            if (!Validate(command).IsValid)
                return;

            var applicant = GetApplicant(command);
            var program = _unitOfWork.ProgramRepository.Find(command.ProgramId);
            var minor = _unitOfWork.MinorRepository.Find(command.MinorId);
            var application = new Application(applicant, program, minor);

            _unitOfWork.ApplicationRepository.Create(application);
            _unitOfWork.ApplicantRepository.Update(applicant);
            _unitOfWork.Commit();
        }

        public void CreateApplications(IEnumerable<CreateApplication> commands)
        {
            foreach (var command in commands)
                CreateApplication(command);
        }

        public IValidationResult Validate(CreateApplication command)
        {
            var validationResult = new ValidationResult(
                _createApplicationValidator.Validate(command)
            );

            return validationResult;
        }

        #endregion

        private Applicant GetApplicant(CreateApplication command)
        {
            if (command.ApplicantId == 0)
                CreateApplicant(command.ApplicantName, command.ApplicantSurname);

            var applicant = _unitOfWork.ApplicantRepository.Find(command.ApplicantId);
            applicant.UpdateName(command.ApplicantName);
            applicant.UpdateSurname(command.ApplicantSurname);

            return applicant;
        }

        private void CreateApplicant(string name, string surname)
        {
            var applicant = new Applicant(name, surname);

            _unitOfWork.ApplicantRepository.Create(applicant);
            _unitOfWork.Commit();
        }
    }
}
