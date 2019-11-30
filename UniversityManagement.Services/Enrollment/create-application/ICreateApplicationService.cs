using System.Collections.Generic;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Domain.Write;

namespace UniversityManagement.Services.Enrollment
{
    public interface ICreateApplicationService
    {
        IEnumerable<College> FetchColleges();
        IEnumerable<Minor> FetchMinors();
        IEnumerable<Program> FetchPrograms(Application application);

        void CreateApplication(Application application);
        IValidationResult Validate(Application application);
    }
}
