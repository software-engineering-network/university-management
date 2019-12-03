namespace UniversityManagement.Infrastructure.Memory.Database
{
    public abstract class Entity
    {
        #region Properties

        public long Id { get; set; }

        #endregion

        #region Construction

        protected Entity()
        {
        }

        protected Entity(long id)
        {
            Id = id;
        }

        #endregion
    }
}
