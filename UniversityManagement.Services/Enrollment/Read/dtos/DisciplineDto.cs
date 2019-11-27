namespace UniversityManagement.Services.Enrollment.Read
{
    public class DisciplineDto : EntityDto
    {
        public CollegeDto College { get; set; }
        public string Name { get; set; }
    }
}
