namespace UniversityManagement.Services.Enrollment
{
    public class CollegeDto : EntityDto
    {
        #region Properties

        public string Name { get; set; }

        #endregion

        #region Construction

        public CollegeDto()
        {
        }

        public CollegeDto(
            long id,
            string name
        )
            : base(id)
        {
            Name = name;
        }

        #endregion

        #region object Overrides

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
