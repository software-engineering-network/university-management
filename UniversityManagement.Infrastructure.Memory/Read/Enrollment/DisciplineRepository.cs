using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read;
using UniversityManagement.Infrastructure.Memory.Database;
using Discipline = UniversityManagement.Domain.Read.Discipline;

namespace UniversityManagement.Infrastructure.Memory.Read.Enrollment
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

        public IEnumerable<Discipline> Fetch()
        {
            return _context.Disciplines.Select(Mapper.Map<Database.Discipline, Discipline>);
        }

        public Discipline Find(long id)
        {
            throw new NotSupportedException();
        }
    }
}
