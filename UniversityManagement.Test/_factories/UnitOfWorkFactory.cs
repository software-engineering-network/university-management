using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Wpf.Write;

namespace UniversityManagement.Test
{
    public class UnitOfWorkFactory
    {
        public static UnitOfWork Create(Context context)
        {
            return new UnitOfWork(context);
        }
    }
}
