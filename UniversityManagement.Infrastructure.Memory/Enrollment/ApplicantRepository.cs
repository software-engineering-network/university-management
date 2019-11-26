using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
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

        #region IRepository<Applicant> Members

        public IEnumerable<Applicant> Fetch()
        {
            throw new NotSupportedException();
        }

        public Applicant Find(long id)
        {
            var applicant = _context.People
                .FirstOrDefault(x => x.Id == id);

            return Mapper.Map<Person, Applicant>(applicant);
        }

        #endregion
    }
}
