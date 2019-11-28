namespace UniversityManagement.Domain.Write.Enrollment
{
    public class CreateApplication
    {
        public long ApplicationId { get; }
        public long ApplicantId { get; }
        public string ApplicantName { get; }
        public string ApplicantSurname { get; }
        public long CollegeId { get; }
        public long MajorId { get; }
        public long MinorId { get; }

        public CreateApplication(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long collegeId,
            long majorId,
            long minorId = 0
        )
        {
            ApplicationId = applicationId;
            ApplicantId = applicantId;
            ApplicantName = applicantName;
            ApplicantSurname = applicantSurname;
            CollegeId = collegeId;
            MajorId = majorId;
            MinorId = minorId;
        }
    }
}
