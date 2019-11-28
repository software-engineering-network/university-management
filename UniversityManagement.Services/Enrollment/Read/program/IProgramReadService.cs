using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment.Read
{
    public interface IProgramReadService
    {
        IEnumerable<MajorDto> FetchMajors();
        IEnumerable<MajorDto> FetchMajors(long collegeId);
        IEnumerable<MinorDto> FetchMinors();
    }
}
