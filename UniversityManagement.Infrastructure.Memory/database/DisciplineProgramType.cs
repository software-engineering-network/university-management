namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class DisciplineProgramType : Entity
    {
        #region Properties

        public long DisciplineId { get; set; }
        public long ProgramTypeId { get; set; }

        #endregion

        #region Construction

        public DisciplineProgramType(
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
