namespace UniversityManagement.Domain.Write.Enrollment
{
    public class CreateApplication
    {
        #region Properties

        public long ApplicantId { get; }
        public string ApplicantName { get; }
        public string ApplicantSocialSecurityNumber { get; }
        public string ApplicantSurname { get; }
        public long ApplicationId { get; }
        public long MinorId { get; }
        public long ProgramId { get; }

        #endregion

        #region Construction

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

        public CreateApplication(Read.Enrollment.Application application) : this(
            application.Id,
            application.Applicant?.Id ?? 0,
            application.Applicant?.Name,
            application.Applicant?.Surname,
            application.Applicant?.SocialSecurityNumber,
            application.Program?.Id ?? 0,
            application.Minor?.Id ?? 0
        )
        {
        }

        #endregion
    }
}
