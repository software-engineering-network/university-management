using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment
{
    public interface ICollegeReadService
    {
        IEnumerable<CollegeDto> FetchColleges();
    }
}
