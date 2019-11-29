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
            var application = new Application(applicant);

            var college = GetCollege(command.CollegeId);
            application.UpdateCollege(college);

            var major = GetMajor(command);
            application.UpdateMajor(major);

            // minor

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

        public void CreateApplications(IEnumerable<CreateApplication> commands)
        {
            foreach (var command in commands)
                CreateApplication(command);
        }

        #endregion
    }
}