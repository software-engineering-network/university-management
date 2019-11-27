using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using Application = UniversityManagement.Domain.Read.Enrollment.Application;
using College = UniversityManagement.Infrastructure.Memory.Database.College;

namespace UniversityManagement.Infrastructure.Memory.Read.Enrollment
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
                );

            var spread2 = spread
                .Join(
                    _context.Colleges,
                    x => x.Application.CollegeId,
                    college => college.Id,
                    (x, College) => new {x.Application, x.Applicant, College}
                );

            var spread3 = spread2
                .Join(
                    programs,
                    x => x.Application.MajorId,
                    x => x.Program.Id,
                    (x, y) => new
                    {
                        x.Application, x.Applicant, x.College, Major = y.Program, MajorDiscipline = y.Discipline,
                        MajorDisciplineCollege = y.College
                    }
                );

            var spread4 = spread3
                .GroupJoin(
                    programs,
                    x => x.Application.MinorId,
                    x => x.Program.Id,
                    (x, Minors) => new
                    {
                        x.Application, x.Applicant, x.College, x.Major, x.MajorDiscipline, x.MajorDisciplineCollege,
                        Minors
                    }
                );

            var spread5 = spread4
                .SelectMany(
                    x => x.Minors.DefaultIfEmpty(),
                    (x, y) => new
                    {
                        x.Application, x.Applicant, x.College, x.Major, x.MajorDiscipline, x.MajorDisciplineCollege,
                        Minor = y?.Program, MinorDiscipline = y?.Discipline, MinorDisciplineCollege = y?.College
                    }
                );

            var spread6 = spread5
                .FirstOrDefault(x => x.Application.Id == id);

            if (spread6 == null)
                return null;

            var application = Mapper.Map<Database.Application, Application>(spread6.Application);
            application.Applicant = Mapper.Map<Person, Applicant>(spread6.Applicant);
            application.College = Mapper.Map<College, Domain.Read.Enrollment.College>(spread6.College);
            application.Major = Mapper.Map<Program, Major>(spread6.Major);
            application.Major.Discipline = Mapper.Map<Discipline, Domain.Read.Discipline>(spread6.MajorDiscipline);
            application.Major.Discipline.College =
                Mapper.Map<College, Domain.Read.Enrollment.College>(spread6.MajorDisciplineCollege);
            application.Minor = Mapper.Map<Program, Minor>(spread6.Minor);

            if (application.Minor == null)
                return application;

            application.Minor.Discipline = Mapper.Map<Discipline, Domain.Read.Discipline>(spread6.MinorDiscipline);
            application.Minor.Discipline.College =
                Mapper.Map<College, Domain.Read.Enrollment.College>(spread6.MinorDisciplineCollege);

            return application;
        }

        #endregion
    }
}
