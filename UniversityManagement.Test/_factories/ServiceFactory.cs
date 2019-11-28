using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class ServiceFactory
    {
        public static IApplicationProcessor CreateApplicationProcessor(IUnitOfWork unitOfWork)
        {
            return new ApplicationProcessor(unitOfWork);
        }
    }
}
