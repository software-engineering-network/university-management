﻿using System.Collections.Generic;

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
            var applicant = command.ApplicantId == 0
                ? CreateApplicant(command)
                : UpdateApplicant(command);

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

        private Applicant CreateApplicant(CreateApplication command)
        {
            var existingApplicant = _unitOfWork.ApplicantRepository.Find(command.ApplicantSocialSecurityNumber);

            if (existingApplicant != null)
                return existingApplicant;

            var applicant = new Applicant(
                command.ApplicantName,
                command.ApplicantSurname,
                command.ApplicantSocialSecurityNumber
            );

            _unitOfWork.ApplicantRepository.Create(applicant);
            _unitOfWork.Commit();

            return _unitOfWork.ApplicantRepository.Find(applicant.SocialSecurityNumber.Value);
        }

        private Applicant UpdateApplicant(CreateApplication command)
        {
            var applicant = _unitOfWork.ApplicantRepository.Find(command.ApplicantId);

            applicant.UpdateName(command.ApplicantName);
            applicant.UpdateSurname(command.ApplicantSurname);
            applicant.UpdateSocialSecurityNumber(command.ApplicantSocialSecurityNumber);

            _unitOfWork.ApplicantRepository.Update(applicant);

            return applicant;
        }
    }
}
