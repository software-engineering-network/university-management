using System.Collections.Generic;
using UniversityManagement.Domain.Write;
using Application = UniversityManagement.Domain.Read.Enrollment.Application;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using Minor = UniversityManagement.Domain.Read.Enrollment.Minor;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;

namespace UniversityManagement.Services.Enrollment
{
    public interface ICreateApplicationService
    {
        IEnumerable<College> FetchColleges();
        IEnumerable<Minor> FetchMinors();
        IEnumerable<Program> FetchPrograms();
        IEnumerable<Program> FetchPrograms(long collegeId);

        void CreateApplication(Application application);
        IValidationResult Validate(Application application);
    }
}
