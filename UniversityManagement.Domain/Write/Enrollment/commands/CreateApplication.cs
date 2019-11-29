namespace UniversityManagement.Domain.Write.Enrollment
{
    public class CreateApplication
    {
        public long ApplicationId { get; }
        public long ApplicantId { get; }
        public string ApplicantName { get; }
        public string ApplicantSurname { get; }
        public long MinorId { get; }
        public long ProgramId { get; }

        public CreateApplication(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long programId,
            long minorId = 0
        )
        {
            ApplicationId = applicationId;
            ApplicantId = applicantId;
            ApplicantName = applicantName;
            ApplicantSurname = applicantSurname;
            MinorId = minorId;
            ProgramId = programId;
        }
    }
}
