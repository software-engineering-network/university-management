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
            var record = _context.People.First(x => x.Id == id);

            return new Applicant(
                record.Id,
                record.Name,
                record.Surname
            );
        }

        public void Create(Applicant applicant)
        {
            var person = Mapper.Map<Applicant, Person>(applicant);
            _context.People.Add(person);
        }

        public void Update(Applicant applicant)
        {
            var candidateApplicant = Mapper.Map<Applicant, Person>(applicant);
            var record = _context.People.First(x => x.Id == applicant.Id);

            if (record == candidateApplicant)
                return;

            Action update = () =>
            {
                record.Name = applicant.Name;
                record.Surname = applicant.Surname;
            };

            _context.People.Update(update);
        }

        #endregion
    }
}
