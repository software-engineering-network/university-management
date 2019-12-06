namespace UniversityManagement.Domain.Write.Enrollment
{
    public class CreateApplication
    {
        public long ApplicationId { get; }
        public long ApplicantId { get; }
        public string ApplicantName { get; }
        public string ApplicantSurname { get; }
        public string ApplicantSocialSecurityNumber { get; }
        public long MinorId { get; }
        public long ProgramId { get; }

        public CreateApplication(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            string applicantSocialSecurityNumber,
            long programId,
            long minorId = 0
        )
        {
            ApplicationId = applicationId;
            ApplicantId = applicantId;
            ApplicantName = applicantName;
            ApplicantSurname = applicantSurname;
            ApplicantSocialSecurityNumber = applicantSocialSecurityNumber;
            MinorId = minorId;
            ProgramId = programId;
        }

        public CreateApplication(Read.Enrollment.Application application)
        {
            ApplicationId = application.Id;
            ApplicantId = application.Applicant?.Id ?? 0;
            ApplicantName = application.Applicant?.Name;
            ApplicantSurname = application.Applicant?.Surname;
            ApplicantSocialSecurityNumber = application.Applicant?.SocialSecurityNumber;
            ProgramId = application.Program?.Id ?? 0;
            MinorId = application.Minor?.Id ?? 0;
        }
    }
}
