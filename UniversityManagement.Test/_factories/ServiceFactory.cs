using UniversityManagement.Domain.Write;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Write;

namespace UniversityManagement.Test
{
    public class ServiceFactory
    {
        public static IApplicationProcessor CreateApplicationProcessor(IApplicationWriteService applicationWriteService)
        {
            return new ApplicationProcessor(applicationWriteService);
        }

        public static IApplicationWriteService CreateApplicationWriteService(IUnitOfWork unitOfWork)
        {
            return new ApplicationWriteService(unitOfWork);
        }
    }
}
