using System;
using System.Collections.Generic;
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

        public IEnumerable<Applicant> Fetch()
        {
            throw new NotSupportedException();
        }

        public Applicant Find(long id)
        {
            var record = _context.People.First(x => x.Id == id);

            return new Applicant(
                record.Id,
                record.Name,
                record.Surname,
                record.SocialSecurityNumber
            );
        }

        public void Create(Applicant applicant)
        {
            var person = new Person(
                applicant.Id,
                applicant.Name,
                applicant.Surname,
                applicant.SocialSecurityNumber.Value
            );

            _context.People.Insert(person);
        }

        public void Update(Applicant applicant)
        {
            var candidatePerson = new Person(
                applicant.Id,
                applicant.Name,
                applicant.Surname,
                applicant.SocialSecurityNumber.Value
            );

            var record = _context.People.First(x => x.Id == applicant.Id);

            if (record == candidatePerson)
                return;

            Action update = () =>
            {
                record.Name = candidatePerson.Name;
                record.Surname = candidatePerson.Surname;
                record.SocialSecurityNumber = candidatePerson.SocialSecurityNumber;
            };

            _context.People.Update(update);
        }

        public Applicant Find(string socialSecurityNumber)
        {
            var record = _context.People.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (record == null)
                return null;

            var applicant = new Applicant(
                record.Id,
                record.Name,
                record.Surname,
                record.SocialSecurityNumber
            );

            return applicant;
        }

        #endregion
    }
}
