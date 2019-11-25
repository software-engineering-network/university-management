using System.Collections.Generic;

namespace UniversityManagement.Domain
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> Fetch();
    }
}
