using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using College = UniversityManagement.Domain.Read.Enrollment.College;

namespace UniversityManagement.Infrastructure.Memory.Read.Enrollment
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

        public IEnumerable<College> Fetch()
        {
            return _context.Colleges.Select(Mapper.Map<Database.College, College>);
        }

        public College Find(long id)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
