using System.Linq;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using College = UniversityManagement.Domain.Write.Enrollment.College;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
{
    public class CollegeRepository : ICollegeRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public CollegeRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region ICollegeRepository Members

        public College Find(long id)
        {
            var college = _context.Colleges.First(x => x.Id == id);

            return new College(
                college.Id,
                college.Name
            );
        }

        #endregion
    }
}
