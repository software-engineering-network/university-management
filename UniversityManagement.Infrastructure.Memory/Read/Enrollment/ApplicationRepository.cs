using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using Application = UniversityManagement.Domain.Read.Enrollment.Application;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;

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

        public IEnumerable<Application> Fetch()
        {
            throw new NotSupportedException();
        }

        public Application Find(long id)
        {
            var record = _context.Applications.FirstOrDefault(x => x.Id == id);

            if (record == null)
                return null;
            
            var application = Mapper.Map<Database.Application, Application>(record);

            application.Applicant = Mapper.Map<Person, Applicant>(
                _context.People.FirstOrDefault(x => x.Id == record.ApplicantId)
            );

            application.College = Mapper.Map<Database.College, College>(
                _context.Colleges.FirstOrDefault(x => x.Id == record.CollegeId)
            );

            application.Minor = Mapper.Map<Database.Program, Minor>(
                _context.Programs.FirstOrDefault(x => x.Id == record.MinorId)
            );

            application.Program = Mapper.Map<Database.Program, Program>(
                _context.Programs.FirstOrDefault(x => x.Id == record.ProgramId)
            );

            return application;
        }
    }
}
