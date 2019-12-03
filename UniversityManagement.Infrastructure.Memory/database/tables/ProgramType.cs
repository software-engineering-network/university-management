namespace UniversityManagement.Infrastructure.Memory.Database
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
