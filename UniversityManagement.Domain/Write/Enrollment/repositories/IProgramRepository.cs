using System.Collections.Generic;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public interface IProgramRepository : IReadRepository<Program>
    {
        IEnumerable<Program> Fetch(long collegeId);
    }
}
