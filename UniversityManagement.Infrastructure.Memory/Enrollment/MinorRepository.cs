using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
{
    public class MinorRepository : IMinorRepository
    {
        private const long MinorProgramTypeId = 4;

        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public MinorRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IMinorRepository Members

        public IEnumerable<Minor> Fetch()
        {
            var programs = _context.Programs;
            var disciplines = _context.Disciplines;

            return programs
                .Where(x => x.ProgramTypeId == MinorProgramTypeId)
                .Join(
                    disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (Program, Discipline) => new {Program, Discipline}
                )
                .Select(
                    x => new Minor(
                        x.Discipline.CollegeId,
                        x.Discipline.Id,
                        x.Program.Id
                    )
                );
        }

        public Minor Find(long id)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
