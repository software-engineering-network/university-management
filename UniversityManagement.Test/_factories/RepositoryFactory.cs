using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Infrastructure.Memory.Read.Enrollment;

namespace UniversityManagement.Test
{
    public class RepositoryFactory
    {
        public static IApplicationRepository CreateApplicationRepository(Context context)
        {
            return new ApplicationRepository(context);
        }
    }
}
