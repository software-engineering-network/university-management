using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Enrollment;

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

        public IEnumerable<Domain.Enrollment.Application> Fetch()
        {
            throw new NotSupportedException();
        }

        public Domain.Enrollment.Application Find(long id)
        {
            var people = _context.People;
            var spread = _context.Applications
                .Join(
                    people,
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

            var application = new Domain.Enrollment.Application(
                    new Applicant(
                        spread.Applicant.Name,
                        spread.Applicant.Surname,
                        spread.Applicant.Id
                    ),
                    spread.Application.Id
                )
                .SelectCollege(new Domain.Enrollment.College(spread.College.Name, spread.College.Id))
                .SelectMajor(new Major(spread.College.Id, spread.Major.DisciplineId, spread.Major.Id));

            if (spread.Minor != null)
                application.SelectMinor(new Minor(0, spread.Minor.DisciplineId, spread.Minor.Id));

            return application;
        }

        #endregion
    }
}
