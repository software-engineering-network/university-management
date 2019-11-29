namespace UniversityManagement.Domain.Read.Enrollment
{
    public class College : Entity
    {
        #region Properties

        public string Name { get; }

        #endregion

        public College(long id, string name) : base(id)
        {
            Name = name;
        }
    }
}
