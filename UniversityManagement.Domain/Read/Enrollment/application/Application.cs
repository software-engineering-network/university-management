namespace UniversityManagement.Domain.Read.Enrollment
{
    public class Application : Entity
    {
        public Applicant Applicant { get; set; }
        public College College { get; set; }
        public Major Major { get; set; }
        public Minor Minor { get; set; }
    }
}
