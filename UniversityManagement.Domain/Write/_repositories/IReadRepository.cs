using System.Collections.Generic;

namespace UniversityManagement.Domain.Write
{
    public interface IReadRepository<T> where T : Entity
    {
        IEnumerable<T> Fetch();
        T Find(long id);
    }
}
