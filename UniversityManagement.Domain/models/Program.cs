namespace UniversityManagement.Domain
{
    public class Program : Entity
    {
        #region Properties

        public long DisciplineId { get; }
        public long CollegeId { get; }
        public ProgramType ProgramType { get; }

        #endregion

        #region Construction

        public Program(
            long collegeId,
            long disciplineId,
            ProgramType programType,
            long id = 0
        ) : base(id)
        {
            CollegeId = collegeId;
            DisciplineId = disciplineId;
            ProgramType = programType;
        }

        #endregion
    }
}
