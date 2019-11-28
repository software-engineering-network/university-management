using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Services.Enrollment.Write
{
    public interface IApplicationWriteService
    {
        CreateApplication BuildCreateApplicationCommand(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long collegeId,
            long majorId,
            long minorId
        );

        void Create(ApplicationDto application);
        void Create(CreateApplication command);
    }
}
