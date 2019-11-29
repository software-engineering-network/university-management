namespace UniversityManagement.Services.Enrollment.Read
{
    public class ApplicationDto : EntityDto
    {
        #region Properties

        public ApplicantDto Applicant { get; set; }
        public CollegeDto College { get; set; }
        public ProgramDto Program { get; set; }
        public MinorDto Minor { get; set; }

        #endregion
    }
}
