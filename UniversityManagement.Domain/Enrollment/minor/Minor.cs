namespace UniversityManagement.Domain.Enrollment
{
    public class Minor : Program
    {
        #region Construction

        public Minor(
            long collegeId,
            long disciplineId,
            long id = 0
        ) : base(
            collegeId,
            disciplineId,
            ProgramType.Minor,
            id
        )
        {
        }

        #endregion
    }
}
