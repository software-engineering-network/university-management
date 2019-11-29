using System.Collections.Generic;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Services.Enrollment
{
    public interface IEditApplicationService
    {
        IEnumerable<CollegeDto> FetchColleges();
        IEnumerable<MinorDto> FetchMinors();
        IEnumerable<ProgramDto> FetchPrograms(ApplicationDto application);

        void CreateApplication(ApplicationDto application);
    }
}
