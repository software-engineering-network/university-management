namespace UniversityManagement.Infrastructure.Memory
{
    public abstract class Entity
    {
        #region Properties

        public long Id { get; set; }

        #endregion

        #region Construction

        protected Entity(long id)
        {
            Id = id;
        }

        #endregion
    }
}
