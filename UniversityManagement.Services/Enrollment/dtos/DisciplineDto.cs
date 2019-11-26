namespace UniversityManagement.Services.Enrollment
{
    public class DisciplineDto : EntityDto
    {
        public CollegeDto College { get; set; }
        public string Name { get; set; }
    }
}
