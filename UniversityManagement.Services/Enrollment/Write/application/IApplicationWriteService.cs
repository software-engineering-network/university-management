using UniversityManagement.Domain.Enrollment.Write;

namespace UniversityManagement.Services.Enrollment.Write
{
    public interface IApplicationWriteService
    {
        void CreateApplication(CreateApplication command);
    }
}
