using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using Discipline = UniversityManagement.Domain.Read.Discipline;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;

namespace UniversityManagement.Infrastructure.Memory.Read.Enrollment
{
    public class ProgramRepository : IProgramRepository
    {
        private const long MajorProgramTypeId = 3;

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
            var majors = _context.Programs
                .Where(x => x.ProgramTypeId == MajorProgramTypeId)
                .Join(
                    _context.Disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (Program, Discipline) => new {Program, Discipline}
                )
                .Join(
                    _context.Colleges,
                    x => x.Discipline.CollegeId,
                    college => college.Id,
                    (x, College) => new {x.Program, x.Discipline, College}
                )
                .Select(
                    x =>
                    {
                        var major = Mapper.Map<Database.Program, Program>(x.Program);
                        major.Discipline = Mapper.Map<Database.Discipline, Discipline>(x.Discipline);
                        major.Discipline.College = Mapper.Map<Database.College, College>(x.College);
                        return major;
                    }
                );

            return majors;
        }

        public Program Find(long id)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<Program> Fetch(long collegeId)
        {
            var majors = Fetch().ToList();
            return majors.Where(x => x.College.Id == collegeId);
        }

        #endregion
    }
}
