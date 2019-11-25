namespace UniversityManagement.Services.Enrollment
{
    public class MajorDto : EntityDto
    {
        public string Name { get; set; }

        public MajorDto()
        {
        }

        public MajorDto(
            long id,
            string name
        )
            : base(id)
        {
            Name = name;
        }
    }
}
