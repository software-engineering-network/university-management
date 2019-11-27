using System.Collections.Generic;

namespace UniversityManagement.Domain.Enrollment.Read
{
    public interface IMajorRepository : IRepository<Major>
    {
        IEnumerable<Major> Fetch(long collegeId);
    }
}
