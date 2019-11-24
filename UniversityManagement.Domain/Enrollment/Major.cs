namespace UniversityManagement.Domain.Enrollment
{
    public class Major : Entity
    {
        public string Name { get; }

        public Major(string name)
        {
            Name = name;
        }
    }
}
