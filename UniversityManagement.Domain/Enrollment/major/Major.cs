namespace UniversityManagement.Domain.Enrollment
{
    public class Major : Program
    {
        #region Construction

        public Major(
            long collegeId,
            long disciplineId,
            ProgramType programType,
            long id = 0
        ) : base(
            collegeId,
            disciplineId, 
            programType,
            id
        )
        {
        }

        #endregion
    }
}
