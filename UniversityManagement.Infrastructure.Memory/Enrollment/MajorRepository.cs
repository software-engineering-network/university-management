using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
{
    public class MajorRepository : IMajorRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public MajorRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IMajorRepository Members

        public IEnumerable<Major> Fetch()
        {
            return _context.Disciplines.Select(
                x => new Major(
                    x.CollegeId,
                    x.Name,
                    x.Id
                )
            );
        }

        public IEnumerable<Major> Fetch(int collegeId)
        {
            return Fetch().Where(x => x.CollegeId == collegeId);
        }

        #endregion
    }
}
