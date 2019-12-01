using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Infrastructure.Memory.Database;
using Applicant = UniversityManagement.Domain.Read.Enrollment.Applicant;
using IApplicantRepository = UniversityManagement.Domain.Read.Enrollment.IApplicantRepository;

namespace UniversityManagement.Infrastructure.Memory.Read.Enrollment
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

        #region IWriteRepository<Applicant> Members

        public IEnumerable<Applicant> Fetch()
        {
            throw new NotSupportedException();
        }

        public Applicant Find(long id)
        {
            var applicant = _context.People.FirstOrDefault(x => x.Id == id);
            return Mapper.Map<Person, Applicant>(applicant);
        }

        public Applicant Find(string socialSecurityNumber)
        {
            var applicant = _context.People.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);
            return Mapper.Map<Person, Applicant>(applicant);
        }

        #endregion
    }
}
