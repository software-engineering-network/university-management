namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class College : Entity
    {
        #region Properties

        public string Name { get; set; }

        #endregion

        #region Construction

        public College(
            long id,
            string name
        ) : base(id)
        {
            Name = name;
        }

        #endregion
    }
}
