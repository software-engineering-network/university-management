using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Domain.Read
{
    public class Program : Entity
    {
        #region Properties

        public Discipline Discipline { get; set; }
        public College College => Discipline.College;
        public ProgramType ProgramType { get; set; }

        #endregion
    }
}
