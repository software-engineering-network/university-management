using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Enrollment.Read;
using UniversityManagement.Infrastructure.Memory.Database;
using Application = UniversityManagement.Domain.Enrollment.Read.Application;
using College = UniversityManagement.Domain.Enrollment.Read.College;

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
                    _context.Programs,
                    x => x.Application.MajorId,
                    major => major.Id,
                    (x, Major) => new {x.Application, x.Applicant, x.College, Major}
                )
                .GroupJoin(
                    _context.Programs,
                    x => x.Application.MinorId,
                    minor => minor.Id,
                    (x, Minors) => new {x.Application, x.Applicant, x.College, x.Major, Minors}
                )
                .SelectMany(
                    x => x.Minors.DefaultIfEmpty(),
                    (x, Minor) => new {x.Application, x.Applicant, x.College, x.Major, Minor}
                )
                .FirstOrDefault(x => x.Application.Id == id);

            if (spread == null)
                return null;

            var application = Mapper.Map<Database.Application, Application>(spread.Application);
            application.Applicant = Mapper.Map<Person, Applicant>(spread.Applicant);
            application.College = Mapper.Map<Database.College, College>(spread.College);
            application.Major = Mapper.Map<Program, Major>(spread.Major);
            application.Minor = Mapper.Map<Program, Minor>(spread.Minor);

            return application;
        }

        #endregion
    }
}
