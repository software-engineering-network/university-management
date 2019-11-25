namespace UniversityManagement.Services.Enrollment
{
    public class CollegeDto : EntityDto
    {
        public string Name { get; set; }

        public CollegeDto()
        {
        }

        public CollegeDto(
            long id,
            string name
        ) 
            : base(id)
        {
            Name = name;
        }
    }
}
