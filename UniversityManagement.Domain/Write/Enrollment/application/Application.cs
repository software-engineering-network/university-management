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

        public Application SetApplicant(Applicant applicant)
        {
            ApplicantId = applicant.Id;
            return this;
        }

        public Application SetCollege(College college)
        {
            CollegeId = college.Id;
            return this;
        }

        public Application SetMajor(Major major)
        {
            MajorId = major.Id;
            return this;
        }
    }
}
