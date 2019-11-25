namespace UniversityManagement.Domain.Enrollment
{
    public class Major : Entity
    {
        public long CollegeId { get; set; }
        public string Name { get; }

        public Major(
            long collegeId,
            string name,
            long id = 0
        ) : base(id)
        {
            CollegeId = collegeId;
            Name = name;
        }
    }
}
