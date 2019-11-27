using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Services.Enrollment.Write
{
    public interface IApplicationWriteService
    {
        void CreateApplication(CreateApplication command);
    }
}
