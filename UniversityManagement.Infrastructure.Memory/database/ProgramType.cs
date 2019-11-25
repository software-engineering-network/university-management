namespace UniversityManagement.Infrastructure.Memory
{
    public class ProgramType : Entity
    {
        public string Name { get; set; }

        public ProgramType(
            long id,
            string name
        ) : base(id)
        {
            Name = name;
        }
    }
}
