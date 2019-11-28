using UniversityManagement.Infrastructure.Memory.Database;

namespace UniversityManagement.Test
{
    public class ContextFactory
    {
        public static Context Create()
        {
            return new Context();
        }
    }
}
