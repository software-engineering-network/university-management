namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class Program : Entity
    {
        #region Properties

        public long DisciplineId { get; set; }
        public long ProgramTypeId { get; set; }

        #endregion

        #region Construction

        public Program(
            long id,
            long disciplineId,
            long programTypeId
        ) : base(id)
        {
            DisciplineId = disciplineId;
            ProgramTypeId = programTypeId;
        }

        #endregion
    }
}
