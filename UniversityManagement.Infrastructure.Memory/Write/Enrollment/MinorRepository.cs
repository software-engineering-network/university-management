using System.Linq;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;

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

        public Minor Find(long id)
        {
            var minor = _context.Programs
                .Where(x => x.Id == id)
                .Join(
                    _context.Disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (program, discipline) => new Minor(
                        program.Id,
                        discipline.CollegeId,
                        discipline.Id,
                        ProgramTypeExtensions.ToEnum(program.ProgramTypeId)
                    )
                )
                .FirstOrDefault();

            return minor;
        }
    }
}
