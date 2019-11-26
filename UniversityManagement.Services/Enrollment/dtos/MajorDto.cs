namespace UniversityManagement.Services.Enrollment
{
    public class MajorDto : EntityDto
    {
        public CollegeDto College { get; set; }
        public DisciplineDto Discipline { get; set; }
        public string Name => Discipline?.Name;
    }
}
