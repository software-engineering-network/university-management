namespace UniversityManagement.Domain.Enrollment
{
    public class Program : Entity
    {
        #region Properties

        public long CollegeId { get; }
        public string Name { get; }
        public ProgramType ProgramType { get; }

        #endregion

        #region Construction

        public Program(
            long collegeId,
            string name,
            ProgramType programType,
            long id = 0
        ) : base(id)
        {
            CollegeId = collegeId;
            Name = name;
            ProgramType = programType;
        }

        #endregion
    }
}
