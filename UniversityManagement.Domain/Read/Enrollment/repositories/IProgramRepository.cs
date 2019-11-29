using System.Collections.Generic;

namespace UniversityManagement.Domain.Read.Enrollment
{
    public interface IProgramRepository : IRepository<Program>
    {
        IEnumerable<Program> Fetch(long collegeId);
    }
}
