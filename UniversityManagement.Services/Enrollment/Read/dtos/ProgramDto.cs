namespace UniversityManagement.Services.Enrollment.Read
{
    public class ProgramDto : EntityDto
    {
        #region Properties

        public CollegeDto College { get; set; }
        public DisciplineDto Discipline { get; set; }
        public string Name => Discipline?.Name;

        #endregion
    }
}
