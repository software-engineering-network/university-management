namespace UniversityManagement.Domain.Read.Enrollment
{
    public class Program : Entity
    {
        #region Properties

        public College College => Discipline?.College;
        public Discipline Discipline { get; set; }
        public ProgramType ProgramType { get; set; }

        #endregion
    }
}
