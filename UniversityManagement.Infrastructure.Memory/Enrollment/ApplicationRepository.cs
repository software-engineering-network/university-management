using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Enrollment.Read;
using UniversityManagement.Infrastructure.Memory.Database;
using Application = UniversityManagement.Domain.Enrollment.Read.Application;
using College = UniversityManagement.Domain.Enrollment.Read.College;
using Discipline = UniversityManagement.Domain.Read.Discipline;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
{
    public class ApplicationRepository : IApplicationRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public ApplicationRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IApplicationRepository Members

        public IEnumerable<Application> Fetch()
        {
            throw new NotSupportedException();
        }

        public Application Find(long id)
        {
            var disciplines = _context.Disciplines
                .Join(
                    _context.Colleges,
                    discipline => discipline.CollegeId,
                    college => college.Id,
                    (Discipline, College) => new {Discipline, College}
                )
                .ToList();

            var programs = _context.Programs
                .Join(
                    disciplines,
                    program => program.DisciplineId,
                    x => x.Discipline.Id,
                    (Program, x) => new {Program, x.College, x.Discipline}
                )
                .ToList();

            var spread = _context.Applications
                .Join(
                    _context.People,
                    x => x.ApplicantId,
                    applicant => applicant.Id,
                    (Application, Applicant) => new {Application, Applicant}
                )
                .Join(
                    _context.Colleges,
                    x => x.Application.CollegeId,
                    college => college.Id,
                    (x, College) => new {x.Application, x.Applicant, College}
                )
                .Join(
                    programs,
                    x => x.Application.MajorId,
                    x => x.Program.Id,
                    (x, y) => new {x.Application, x.Applicant, x.College, Major = y.Program, MajorDiscipline = y.Discipline, MajorDisciplineCollege = y.College}
                )
                .GroupJoin(
                    programs,
                    x => x.Application.MinorId,
                    x => x.Program.Id,
                    (x, Minors) => new { x.Application, x.Applicant, x.College, x.Major, x.MajorDiscipline, x.MajorDisciplineCollege, Minors}
                )
                .SelectMany(
                    x => x.Minors.DefaultIfEmpty(),
                    (x, y) => new {x.Application, x.Applicant, x.College, x.Major, x.MajorDiscipline, x.MajorDisciplineCollege, Minor = y?.Program, MinorDiscipline = y?.Discipline, MinorDisciplineCollege = y?.College}
                )
                .FirstOrDefault(x => x.Application.Id == id);

            if (spread == null)
                return null;

            var application = Mapper.Map<Database.Application, Application>(spread.Application);
            application.Applicant = Mapper.Map<Person, Applicant>(spread.Applicant);
            application.College = Mapper.Map<Database.College, College>(spread.College);
            application.Major = Mapper.Map<Program, Major>(spread.Major);
            application.Major.Discipline = Mapper.Map<Database.Discipline, Discipline>(spread.MajorDiscipline);
            application.Major.Discipline.College = Mapper.Map<Database.College, College>(spread.MajorDisciplineCollege);
            application.Minor = Mapper.Map<Program, Minor>(spread.Minor);
            
            if (application.Minor == null)
                return application;

            application.Minor.Discipline = Mapper.Map<Database.Discipline, Discipline>(spread.MinorDiscipline);
            application.Minor.Discipline.College = Mapper.Map<Database.College, College>(spread.MinorDisciplineCollege);

            return application;
        }

        #endregion
    }
}
