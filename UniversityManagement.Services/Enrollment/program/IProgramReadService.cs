using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment
{
    public interface IProgramReadService
    {
        IEnumerable<MajorDto> FetchMajors();
        IEnumerable<MajorDto> FetchMajors(long collegeId);
    }
}
