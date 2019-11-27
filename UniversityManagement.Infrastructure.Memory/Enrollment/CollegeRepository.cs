using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Enrollment.Read;
using UniversityManagement.Infrastructure.Memory.Database;
using College = UniversityManagement.Domain.Enrollment.Read.College;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
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
