using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment
{
    public interface IProgramReadService
    {
        IEnumerable<MajorDto> Fetch();
        IEnumerable<MajorDto> Fetch(long collegeId);
    }
}
