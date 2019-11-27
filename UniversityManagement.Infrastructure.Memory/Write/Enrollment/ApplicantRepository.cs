using System;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
{
    public class ApplicantRepository : IApplicantRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public ApplicantRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IApplicantRepository Members

        public Applicant Find(long id)
        {
            var record = _context.People.FirstOrDefault(x => x.Id == id);

            var applicant = record == null
                ? null
                : new Applicant(
                    record.Name,
                    record.Surname,
                    record.Id
                );

            return applicant;
        }

        #endregion
    }
}
