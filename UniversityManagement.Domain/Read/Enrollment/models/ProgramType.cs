namespace UniversityManagement.Domain.Read.Enrollment
{
    public class ProgramType : Entity
    {
        public string Name { get; set; }
        public bool IsConcentration { get; set; }
        public bool IsMinor { get; set; }
        public bool IsProgram { get; set; }
    }
}
