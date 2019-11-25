namespace UniversityManagement.Domain.Enrollment
{
    public class College : Entity
    {
        public string Name { get; }

        public College(
            string name,
            long id = 0
        ) : base(id)
        {
            Name = name;
        }
    }
}
