namespace UniversityManagement.Domain.Enrollment
{
    public class College : Entity
    {
        public string Name { get; }

        public College(string name)
        {
            Name = name;
        }
    }
}
