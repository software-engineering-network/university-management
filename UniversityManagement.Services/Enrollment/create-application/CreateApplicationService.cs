using System.Collections.Generic;
using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
using Application = UniversityManagement.Domain.Read.Enrollment.Application;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using ICollegeRepository = UniversityManagement.Domain.Read.Enrollment.ICollegeRepository;
using IMinorRepository = UniversityManagement.Domain.Read.Enrollment.IMinorRepository;
using IProgramRepository = UniversityManagement.Domain.Read.Enrollment.IProgramRepository;
using Minor = UniversityManagement.Domain.Read.Enrollment.Minor;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;

namespace UniversityManagement.Services.Enrollment
{
    public class CreateApplicationService : ICreateApplicationService
    {
        #region Fields

        private readonly IApplicationProcessor _applicationProcessor;
        private readonly ICollegeRepository _collegeRepository;
        private readonly IMinorRepository _minorRepository;
        private readonly IProgramRepository _programRepository;

        #endregion

        #region Construction

        public CreateApplicationService(
            IApplicationProcessor applicationProcessor,
            ICollegeRepository collegeRepository,
            IMinorRepository minorRepository,
            IProgramRepository programRepository
        )
        {
            _applicationProcessor = applicationProcessor;
            _collegeRepository = collegeRepository;
            _minorRepository = minorRepository;
            _programRepository = programRepository;
        }

        #endregion

        #region ICreateApplicationService Members

        public IEnumerable<College> FetchColleges()
        {
            return _collegeRepository.Fetch();
        }

        public IEnumerable<Program> FetchPrograms(Application application)
        {
            var programs = application.College == null || application.College.Id == 0
                ? _programRepository.Fetch()
                : _programRepository.Fetch(application.College.Id);

            return programs;
        }

        public IEnumerable<Minor> FetchMinors()
        {
            return _minorRepository.Fetch();
        }

        public void CreateApplication(Application application)
        {
            //_applicationProcessor.CreateApplication(application);
        }

        public IValidationResult Validate(Application application)
        {
            var command = ToCreateApplicationCommand(application);
            var validationResult = _applicationProcessor.Validate(command);
            return validationResult;
        }

        #endregion

        private static CreateApplication ToCreateApplicationCommand(Application application)
        {
            return new CreateApplication(
                application.Id,
                application.Applicant?.Id ?? 0,
                application.Applicant?.Name ?? string.Empty,
                application.Applicant?.Surname ?? string.Empty,
                application.Program?.Id ?? 0,
                application.Minor?.Id ?? 0
            );
        }
    }
}
