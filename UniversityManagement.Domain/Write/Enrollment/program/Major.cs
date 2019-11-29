namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Major : Program
    {
        #region Construction

        public Major(long id, long disciplineId) : base(id, disciplineId, ProgramType.Major)
        {
        }

        #endregion
    }
}
