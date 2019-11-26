using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Enrollment;

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

        public IEnumerable<Domain.Enrollment.College> Fetch()
        {
            return _context.Colleges.Select(
                x => new Domain.Enrollment.College(
                    x.Name,
                    x.Id
                )
            );
        }

        public Domain.Enrollment.College Find(long id)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
