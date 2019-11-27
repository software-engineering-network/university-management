namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class Discipline : Entity
    {
        #region Properties

        public long CollegeId { get; set; }
        public string Name { get; set; }

        #endregion

        #region Construction

        public Discipline(
            long id,
            long collegeId,
            string name
        ) : base(id)
        {
            CollegeId = collegeId;
            Name = name;
        }

        #endregion
    }
}
