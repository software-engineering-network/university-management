using System.Collections.Generic;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Services.Enrollment
{
    public class CreateApplicationService : ICreateApplicationService
    {
        #region Construction

        public CreateApplicationService(
            //IApplicationProcessor applicationProcessor,
            ICollegeRepository collegeRepository,
            IMinorRepository minorRepository,
            IProgramRepository programRepository
        )
        {
            //_applicationProcessor = applicationProcessor;
            _collegeRepository = collegeRepository;
            _minorRepository = minorRepository;
            _programRepository = programRepository;
        }

        #endregion

        #region Fields

        //private readonly IApplicationProcessor _applicationProcessor;
        private readonly ICollegeRepository _collegeRepository;
        private readonly IMinorRepository _minorRepository;
        private readonly IProgramRepository _programRepository;

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

        #endregion
    }
}