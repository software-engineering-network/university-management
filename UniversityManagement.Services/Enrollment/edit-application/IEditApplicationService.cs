using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment
{
    public interface IEditApplicationService
    {
        IEnumerable<CollegeDto> FetchColleges();
        IEnumerable<MajorDto> FetchMajors(ApplicationDto application);

        bool SetCollege(ApplicationDto application, CollegeDto college);
        bool SetMajor(ApplicationDto application, MajorDto major);
    }
}
