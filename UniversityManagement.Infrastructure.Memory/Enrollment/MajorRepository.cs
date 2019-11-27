using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Enrollment.Read;
using UniversityManagement.Infrastructure.Memory.Database;
using College = UniversityManagement.Domain.Enrollment.Read.College;
using Discipline = UniversityManagement.Domain.Read.Discipline;

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
                        var major = Mapper.Map<Program, Major>(x.Program);
                        major.Discipline = Mapper.Map<Database.Discipline, Discipline>(x.Discipline);
                        major.Discipline.College = Mapper.Map<Database.College, College>(x.College);
                        return major;
                    }
                );

            return majors;
        }

        public Major Find(long id)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<Major> Fetch(long collegeId)
        {
            var majors = Fetch().ToList();
            return majors.Where(x => x.College.Id == collegeId);
        }

        #endregion
    }
}
