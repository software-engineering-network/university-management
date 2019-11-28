using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment.Read
{
    public interface ICollegeReadService
    {
        IEnumerable<CollegeDto> Fetch();
    }
}
