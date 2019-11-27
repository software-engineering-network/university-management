using UniversityManagement.Domain.Enrollment.Read;

namespace UniversityManagement.Domain.Read
{
    public class Program : Entity
    {
        #region Properties

        public College College { get; set; }
        public Discipline Discipline { get; set; }
        public ProgramType ProgramType { get; set; }

        #endregion
    }
}
