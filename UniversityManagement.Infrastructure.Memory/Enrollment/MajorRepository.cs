using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
{
    public class MajorRepository : IMajorRepository
    {
        private const long MajorProgramTypeId = 3;

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
            var programs = _context.Programs;
            var disciplines = _context.Disciplines;

            return programs
                .Where(x => x.ProgramTypeId == MajorProgramTypeId)
                .Join(
                    disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (Program, Discipline) => new {Program, Discipline}
                )
                .Select(
                    x => new Major(
                        x.Discipline.CollegeId,
                        x.Discipline.Id,
                        Domain.ProgramType.Major,
                        x.Program.Id
                    )
                );
        }

        public IEnumerable<Major> Fetch(long collegeId)
        {
            var majors = Fetch().ToList();
            return majors.Where(x => x.CollegeId == collegeId);
        }

        #endregion
    }
}
