namespace UniversityManagement.Domain.Read.Enrollment
{
    public class Program : Entity
    {
        public College College { get; set; }
        public Discipline Discipline { get; set; }
        public ProgramType ProgramType { get; set; }

        public string Name => $"{Discipline.Name} - {ProgramType.Name}";
    }
}
