namespace UniversityManagement.Services.Enrollment
{
    public class ApplicationDto : EntityDto
    {
        public ApplicantDto Applicant { get; set; }
        public CollegeDto College { get; set; }
        public MajorDto Major { get; set; }

        public ApplicationDto()
        {
            Applicant = new ApplicantDto();
            College = new CollegeDto();
            Major = new MajorDto();
        }
    }
}
