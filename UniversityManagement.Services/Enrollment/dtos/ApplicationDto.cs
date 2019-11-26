namespace UniversityManagement.Services.Enrollment
{
    public class ApplicationDto : EntityDto
    {
        #region Properties

        public ApplicantDto Applicant { get; set; }
        public CollegeDto College { get; set; }
        public MajorDto Major { get; set; }
        public MinorDto Minor { get; set; }

        #endregion
    }
}
