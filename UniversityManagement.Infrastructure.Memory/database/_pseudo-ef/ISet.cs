namespace UniversityManagement.Infrastructure.Memory.Database
{
    public interface ISet
    {
        #region Properties

        bool HasChanges { get; }

        #endregion

        void Commit();
    }

    public interface ISet<T> : ISet where T : Entity
    {
        void Delete(long id);
        void Insert(T obj);
    }
}
