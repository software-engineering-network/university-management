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

            var application = new Application();

            var applicant = GetApplicant(command);
            //application.SetApplicant(applicant);

            var college = GetCollege(command.CollegeId);
            //application.SetCollege(college);

            var major = GetMajor(command);
            //application.SetMajor(major);

            // minor

            Persist(application, applicant);
        }

        private Applicant GetApplicant(CreateApplication command)
        {
            var applicant = command.ApplicantId == 0
                ? new Applicant(command.ApplicantName, command.ApplicantSurname)
                : _unitOfWork.ApplicantRepository.Find(command.ApplicantId);

            return applicant;
        }

        private College GetCollege(long collegeId)
        {
            return _unitOfWork.CollegeRepository.Find(collegeId);
        }

        private Major GetMajor(CreateApplication command)
        {
            var major = _unitOfWork.MajorRepository.Find(command.MajorId);
            if (major != null)
                return major;

            var majors = _unitOfWork.MajorRepository.Fetch(command.CollegeId).ToList();

            if (majors.Count > 0)
                major = majors.First();

            return major;
        }

        private void Persist(
            Application application,
            Applicant applicant
        )
        {
            _unitOfWork.ApplicationRepository.Create(application);

            if (application.ApplicantId == 0)
                _unitOfWork.ApplicantRepository.Create(applicant);
            else
                _unitOfWork.ApplicantRepository.Update(applicant);

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
