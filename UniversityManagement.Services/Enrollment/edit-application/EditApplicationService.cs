using System.Collections.Generic;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Services.Enrollment
{
    public class EditApplicationService : IEditApplicationService
    {
        #region Fields

        private readonly IApplicationProcessor _applicationProcessor;
        private readonly ICollegeReadService _collegeReadService;
        private readonly IProgramReadService _programReadService;

        #endregion

        #region Construction

        public EditApplicationService(
            IApplicationProcessor applicationProcessor,
            ICollegeReadService collegeReadService,
            IProgramReadService programReadService
        )
        {
            _applicationProcessor = applicationProcessor;
            _collegeReadService = collegeReadService;
            _programReadService = programReadService;
        }

        #endregion

        #region IEditApplicationService Members

        public IEnumerable<CollegeDto> FetchColleges()
        {
            return _collegeReadService.Fetch();
        }

        public IEnumerable<ProgramDto> FetchPrograms(ApplicationDto application)
        {
            var programs = application.College == null || application.College.Id == 0
                ? _programReadService.FetchPrograms()
                : _programReadService.FetchPrograms(application.College.Id);

            return programs;
        }

        public IEnumerable<MinorDto> FetchMinors()
        {
            return _programReadService.FetchMinors();
        }

        public void CreateApplication(ApplicationDto application)
        {
            //_applicationProcessor.CreateApplication(application);
        }

        #endregion
    }
}
