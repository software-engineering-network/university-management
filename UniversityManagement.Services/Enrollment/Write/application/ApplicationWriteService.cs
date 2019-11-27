using UniversityManagement.Domain;
using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Services.Enrollment.Write
{
    public class ApplicationWriteService : IApplicationWriteService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public ApplicationWriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IApplicationWriteService Members

        public void CreateApplication(CreateApplication command)
        {
            // validate command

            // if !isValid return

            var application = new Application();

            var applicant = command.ApplicantId == 0
                ? new Applicant(command.ApplicantName, command.ApplicantSurname)
                : _unitOfWork.ApplicantRepository.Find(command.ApplicantId);

            //var college = _unitOfWork.CollegeRepository.Find(command.CollegeId);
            var major = _unitOfWork.MajorRepository.Find(command.MajorId);

            application
                .SetApplicant(applicant)
                .SetMajor(major);

            // find & add minor

            _unitOfWork.ApplicationRepository.Create(application);
            _unitOfWork.Commit();
        }

        #endregion
    }
}
