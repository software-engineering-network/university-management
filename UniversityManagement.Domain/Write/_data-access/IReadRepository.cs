using System.Collections.Generic;

namespace UniversityManagement.Domain.Write
{
    public interface IReadRepository<T> where T : Entity
    {
        T Find(long id);
    }
}
