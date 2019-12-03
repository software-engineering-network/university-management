using System.Collections.ObjectModel;
using UniversityManagement.Domain.Write;
using Application = UniversityManagement.Domain.Read.Enrollment.Application;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using Minor = UniversityManagement.Domain.Read.Enrollment.Minor;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;

namespace UniversityManagement.Services.Enrollment
{
    public interface ICreateApplicationService
    {
        ObservableCollection<College> FetchColleges();
        ObservableCollection<Minor> FetchMinors();
        ObservableCollection<Program> FetchPrograms();
        ObservableCollection<Program> FetchPrograms(long collegeId);

        void CreateApplication(Application application);
        IValidationResult Validate(Application application);
    }
}
