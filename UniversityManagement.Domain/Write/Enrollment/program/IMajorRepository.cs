using System.Collections.Generic;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public interface IMajorRepository : IReadRepository<Major>
    {
        IEnumerable<Major> Fetch(long collegeId);
    }
}
