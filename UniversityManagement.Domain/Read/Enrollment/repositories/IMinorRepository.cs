using System.Collections.Generic;

namespace UniversityManagement.Domain.Read.Enrollment
{
    public interface IMinorRepository : IRepository<Minor>
    {
        IEnumerable<Minor> Fetch(long collegeId);
    }
}
