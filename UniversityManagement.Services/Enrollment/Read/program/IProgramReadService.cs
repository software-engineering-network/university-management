using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment.Read
{
    public interface IProgramReadService
    {
        IEnumerable<ProgramDto> FetchPrograms();
        IEnumerable<ProgramDto> FetchPrograms(long collegeId);
        IEnumerable<MinorDto> FetchMinors();
    }
}
