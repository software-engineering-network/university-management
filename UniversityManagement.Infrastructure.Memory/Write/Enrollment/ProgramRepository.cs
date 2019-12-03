using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using Program = UniversityManagement.Domain.Write.Enrollment.Program;
using ProgramType = UniversityManagement.Domain.Write.Enrollment.ProgramType;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
{
    public class ProgramRepository : IProgramRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public ProgramRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IProgramRepository Members

        public IEnumerable<Program> Fetch()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Program> Fetch(long collegeId)
        {
            var programs = _context.Programs
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
                    (x, Discipline) => new {x.Program, x.ProgramType, Discipline}
                )
                .Where(x => x.Discipline.CollegeId == collegeId)
                .Select(
                    x => new Program(
                        x.Program.Id,
                        x.Discipline.CollegeId,
                        x.Program.DisciplineId,
                        new ProgramType(x.ProgramType.Id, x.ProgramType.Name)
                    )
                );

            return programs;
        }

        public Program Find(long id)
        {
            return _context.Programs
                .Where(x => x.Id == id)
                .Join(
                    _context.ProgramTypes,
                    program => program.ProgramTypeId,
                    programType => programType.Id,
                    (Program, ProgramType) => new { Program, ProgramType }
                )
                .Join(
                    _context.Disciplines,
                    x => x.Program.DisciplineId,
                    discipline => discipline.Id,
                    (x, Discipline) => new { x.Program, x.ProgramType, Discipline }
                )
                .Select(
                    x => new Program(
                        x.Program.Id,
                        x.Discipline.CollegeId,
                        x.Program.DisciplineId,
                        new ProgramType(x.ProgramType.Id, x.ProgramType.Name)
                    )
                )
                .FirstOrDefault();
        }

        #endregion
    }
}
