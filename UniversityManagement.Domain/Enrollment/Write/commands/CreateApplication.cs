namespace UniversityManagement.Domain.Enrollment.Write
{
    public class CreateApplication
    {
        public long ApplicationId { get; }
        public long ApplicantId { get; }
        public long CollegeId { get; }
        public long MajorId { get; }
        public long MinorId { get; }

        public CreateApplication(
            long applicationId,
            long applicantId,
            long collegeId,
            long majorId,
            long minorId
        )
        {
            ApplicationId = applicationId;
            ApplicantId = applicantId;
            CollegeId = collegeId;
            MajorId = majorId;
            MinorId = minorId;
        }
    }
}
