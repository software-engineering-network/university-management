namespace UniversityManagement.Domain
{
    public class Discipline : Entity
    {
        public long CollegeId { get; }
        public string Name { get; }

        public Discipline()
        {
        }

        public Discipline(
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
