namespace UniversityManagement.Domain.Read.Enrollment
{
    public class College : Entity
    {
        public string Name { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
