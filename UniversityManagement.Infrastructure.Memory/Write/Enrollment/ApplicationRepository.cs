using System;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using Application = UniversityManagement.Domain.Write.Enrollment.Application;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
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

        public void Create(Application application)
        {
            var record = Mapper.Map<Application, Database.Application>(application);
            _context.Applications.Insert(record);
        }

        public void Update(Application application)
        {
            var candidateApplication = Mapper.Map<Application, Database.Application>(application);
            var record = _context.Applications.First(x => x.Id == application.Id);

            if (record == candidateApplication)
                return;

            Action update = () =>
            {
                record.CollegeId = candidateApplication.CollegeId;
                record.MinorId = candidateApplication.MinorId;
                record.ProgramId = candidateApplication.ProgramId;
            };

            _context.Applications.Update(update);
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

        #endregion
    }
}
