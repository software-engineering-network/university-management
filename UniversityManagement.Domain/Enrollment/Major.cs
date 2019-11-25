namespace UniversityManagement.Domain.Enrollment
{
    public class Major : Entity
    {
        public string Name { get; }
        public College College { get; }

        public Major(
            string name,
            College college,
            long id = 0
        ) : base(id)
        {
            Name = name;
            College = college;
        }
    }
}
