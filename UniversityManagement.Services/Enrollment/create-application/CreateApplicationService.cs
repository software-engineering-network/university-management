using System.Collections.Generic;
using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
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

        public IEnumerable<Program> FetchPrograms()
        {
            return _programRepository.Fetch();
        }

        public IEnumerable<Program> FetchPrograms(long collegeId)
        {
            return _programRepository.Fetch(collegeId);
        }

        public IEnumerable<Minor> FetchMinors()
        {
            return _minorRepository.Fetch();
        }

        public void CreateApplication(CreateApplication command)
        {
            _applicationProcessor.CreateApplication(command);
        }

        public IValidationResult Validate(CreateApplication command)
        {
            return _applicationProcessor.Validate(command);
        }

        #endregion
    }
}
