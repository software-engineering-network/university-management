using System.Collections.Generic;

namespace UniversityManagement.Domain.Read.Enrollment
{
    public interface IMajorRepository : IRepository<Major>
    {
        IEnumerable<Major> Fetch(long collegeId);
    }
}
