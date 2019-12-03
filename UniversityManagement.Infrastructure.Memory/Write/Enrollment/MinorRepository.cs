using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using ProgramType = UniversityManagement.Domain.Write.Enrollment.ProgramType;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
{
    public class MinorRepository : IMinorRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public MinorRepository(Context context)
        {
            _context = context;
        }

        #endregion

        public IEnumerable<Minor> Fetch()
        {
            throw new NotSupportedException();
        }

        public Minor Find(long id)
        {
            var minor = _context.Programs
                .Where(x => x.Id == id)
                .Join(
                    _context.ProgramTypes,
                    program => program.ProgramTypeId,
                    programType => programType.Id,
                    (Program, ProgramType) => new {Program, ProgramType}
                )
                .Join(
                    _context.Disciplines,
                    x => x.Program.DisciplineId,
                    discipline => discipline.Id,
                    (x, discipline) => new Minor(
                        x.Program.Id,
                        discipline.CollegeId,
                        discipline.Id,
                        new ProgramType(x.ProgramType.Id, x.ProgramType.Name)
                    )
                )
                .FirstOrDefault();

            return minor;
        }
    }
}
