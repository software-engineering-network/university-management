using ExpressMapper;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using Application = UniversityManagement.Domain.Write.Enrollment.Application;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
{
    public class ApplicationRepository : IApplicationRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public ApplicationRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IApplicationRepository Members

        public void Create(Application application)
        {
            var record = Mapper.Map<Application, Database.Application>(application);
            _context.Applications.Add(record);
        }

        #endregion
    }
}
