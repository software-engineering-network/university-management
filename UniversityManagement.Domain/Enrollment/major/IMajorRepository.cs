using System.Collections.Generic;

namespace UniversityManagement.Domain.Enrollment
{
    public interface IMajorRepository : IRepository<Major>
    {
        IEnumerable<Major> Fetch(int collegeId);
    }
}
