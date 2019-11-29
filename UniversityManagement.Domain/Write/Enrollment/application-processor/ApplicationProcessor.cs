using System.Collections.Generic;
using System.Linq;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class ApplicationProcessor : IApplicationProcessor
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public ApplicationProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IApplicationProcessor Members

        public void CreateApplication(CreateApplication command)
        {
            // validate command

            // if !isValid return

            var applicant = GetApplicant(command);
            var program = _unitOfWork.ProgramRepository.Find(command.ProgramId);
            var application = new Application(applicant, program, null);

            _unitOfWork.ApplicationRepository.Create(application);
            _unitOfWork.ApplicantRepository.Update(applicant);
            _unitOfWork.Commit();
        }

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

        public void CreateApplications(IEnumerable<CreateApplication> commands)
        {
            foreach (var command in commands)
                CreateApplication(command);
        }

        #endregion
    }
}
