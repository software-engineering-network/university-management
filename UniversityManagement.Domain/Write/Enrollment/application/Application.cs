using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Application : Entity
    {
        #region Properties

        public long ApplicantId { get; private set; }
        public long CollegeId { get; private set; }
        public long MajorId { get; private set; }
        public long MinorId { get; private set; }

        #endregion

        public Application(Applicant applicant, Major major)
        {
            SetApplicant(applicant);
            SetMajor(major);
        }

        private void SetApplicant(Applicant applicant)
        {
            if (applicant == null || applicant.Id == 0)
                throw new ArgumentException();

            ApplicantId = applicant.Id;
        }

        private void SetMajor(Major major)
        {
            if (major == null)
                throw new ArgumentException();

            MajorId = major.Id;
            CollegeId = major.CollegeId;
        }
    }
}
