using System.Collections.Generic;
using UniversityManagement.Domain.Read;

namespace UniversityManagement.Domain
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> Fetch();
        T Find(long id);
    }
}
