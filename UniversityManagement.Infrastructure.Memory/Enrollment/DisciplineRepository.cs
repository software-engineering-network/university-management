using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
{
    public class DisciplineRepository : IDisciplineRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public DisciplineRepository(Context context)
        {
            _context = context;
        }

        #endregion

        public IEnumerable<Domain.Discipline> Fetch()
        {
            return _context.Disciplines.Select(
                x => new Domain.Discipline(
                    x.CollegeId,
                    x.Name,
                    x.Id
                )
            );
        }

        public Domain.Discipline Find(long id)
        {
            throw new NotSupportedException();
        }
    }
}
