using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

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

        public CreateApplication BuildCreateApplicationCommand(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long collegeId,
            long majorId,
            long minorId
        )
        {
            return new CreateApplication(
                applicationId,
                applicantId,
                applicantName,
                applicantSurname,
                collegeId,
                majorId,
                minorId
            );
        }

        public void Create(ApplicationDto application)
        {
            var command = BuildCreateApplicationCommand(
                application.Id,
                application.Applicant.Id,
                application.Applicant.Name,
                application.Applicant.Surname,
                application.College.Id,
                application.Major.Id,
                application.Minor.Id
            );

            Create(command);
        }

        public void Create(CreateApplication command)
        {
            // validate command

            // if !isValid return

            var application = new Application();

            var applicant = command.ApplicantId == 0
                ? new Applicant(command.ApplicantName, command.ApplicantSurname)
                : _unitOfWork.ApplicantRepository.Find(command.ApplicantId);

            var college = _unitOfWork.CollegeRepository.Find(command.CollegeId);
            var major = _unitOfWork.MajorRepository.Find(command.MajorId);

            application
                .SetApplicant(applicant)
                .SetCollege(college)
                .SetMajor(major);

            // find & add minor

            _unitOfWork.ApplicationRepository.Create(application);

            if (application.ApplicantId == 0)
                _unitOfWork.ApplicantRepository.Create(applicant);
            else
                _unitOfWork.ApplicantRepository.Update(applicant);

            _unitOfWork.Commit();
        }

        public void Create(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long collegeId,
            long majorId,
            long minorId
        )
        {
            var command = BuildCreateApplicationCommand(
                applicationId,
                applicantId,
                applicantName,
                applicantSurname,
                collegeId,
                majorId,
                minorId
            );

            Create(command);
        }

        #endregion
    }
}
