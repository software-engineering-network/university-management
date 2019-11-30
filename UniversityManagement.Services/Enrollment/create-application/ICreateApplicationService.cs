using System.Collections.Generic;
using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
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

        void CreateApplication(CreateApplication command);
        IValidationResult Validate(CreateApplication command);
    }
}
