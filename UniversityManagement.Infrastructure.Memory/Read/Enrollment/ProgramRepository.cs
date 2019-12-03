using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using Discipline = UniversityManagement.Domain.Read.Enrollment.Discipline;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;
using ProgramType = UniversityManagement.Domain.Read.Enrollment.ProgramType;

namespace UniversityManagement.Infrastructure.Memory.Read.Enrollment
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly long[] ProgramIds = {2, 3, 5, 6};

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
            var programs = _context.Programs
                .Where(x => ProgramIds.Contains(x.ProgramTypeId))
                .Join(
                    _context.Disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (Program, Discipline) => new { Program, Discipline }
                )
                .Join(
                    _context.Colleges,
                    x => x.Discipline.CollegeId,
                    college => college.Id,
                    (x, College) => new { x.Program, x.Discipline, College }
                )
                .Join(
                    _context.ProgramTypes,
                    x => x.Program.ProgramTypeId,
                    programType => programType.Id,
                    (x, ProgramType) => new {x.Program, x.College, x.Discipline, ProgramType}
                )
                .Select(
                    x =>
                    {
                        var program = Mapper.Map<Database.Program, Program>(x.Program);
                        program.College = Mapper.Map<Database.College, College>(x.College);
                        program.Discipline = Mapper.Map<Database.Discipline, Discipline>(x.Discipline);
                        program.ProgramType = Mapper.Map<Database.ProgramType, ProgramType>(x.ProgramType);
                        return program;
                    }
                );

            return programs;
        }

        public Program Find(long id)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<Program> Fetch(long collegeId)
        {
            var programs = Fetch().ToList();
            return programs.Where(x => x.College.Id == collegeId);
        }

        #endregion
    }
}
