using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using Program = UniversityManagement.Domain.Write.Enrollment.Program;
using ProgramType = UniversityManagement.Domain.ProgramType;

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
                    _context.Disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (Program, Discipline) => new {Program, Discipline}
                )
                .Where(x => x.Discipline.CollegeId == collegeId)
                .Select(
                    x => new Program(
                        x.Program.Id,
                        x.Discipline.CollegeId,
                        x.Program.DisciplineId,
                        ProgramTypeExtensions.ToEnum(x.Program.ProgramTypeId)
                    )
                );

            return programs;
        }

        public Program Find(long id)
        {
            return _context.Programs
                .Where(x => x.Id == id)
                .Join(
                    _context.Disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (Program, Discipline) => new { Program, Discipline }
                )
                .Select(
                    x => new Program(
                        x.Program.Id,
                        x.Discipline.CollegeId,
                        x.Program.DisciplineId,
                        ProgramTypeExtensions.ToEnum(x.Program.ProgramTypeId)
                    )
                )
                .FirstOrDefault();
        }

        #endregion
    }

    public static class ProgramTypeExtensions
    {
        private static readonly IDictionary<long, ProgramType> ProgramTypes = new Dictionary<long, ProgramType>
        {
            {1, ProgramType.Concentration},
            {2, ProgramType.GraduateProgram},
            {3, ProgramType.Major},
            {4, ProgramType.Minor},
            {5, ProgramType.Pathway},
            {6, ProgramType.PreprofessionalProgram}
        };

        public static ProgramType ToEnum(this Database.ProgramType record)
        {
            return ToEnum(record.Id);
        }

        public static ProgramType ToEnum(long programTypeId)
        {
            return ProgramTypes[programTypeId];
        }
    }
}
