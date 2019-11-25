namespace UniversityManagement.Domain.Enrollment
{
    public class Major : Program
    {
        #region Construction

        public Major(
            long collegeId,
            string name,
            ProgramType programType,
            long id = 0
        ) : base(collegeId, name, programType, id)
        {
        }

        #endregion
    }
}
