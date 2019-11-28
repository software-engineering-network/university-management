using System.Collections.Generic;
using UniversityManagement.Services.Enrollment.Read;
using UniversityManagement.Services.Enrollment.Write;

namespace UniversityManagement.Services.Enrollment
{
    public class EditApplicationService : IEditApplicationService
    {
        #region Fields

        private readonly IApplicationWriteService _applicationWriteService;
        private readonly ICollegeReadService _collegeReadService;
        private readonly IProgramReadService _programReadService;

        #endregion

        #region Construction

        public EditApplicationService(
            IApplicationWriteService applicationWriteService,
            ICollegeReadService collegeReadService,
            IProgramReadService programReadService
        )
        {
            _applicationWriteService = applicationWriteService;
            _collegeReadService = collegeReadService;
            _programReadService = programReadService;
        }

        #endregion

        #region IEditApplicationService Members

        public IEnumerable<CollegeDto> FetchColleges()
        {
            return _collegeReadService.Fetch();
        }

        public IEnumerable<MajorDto> FetchMajors(ApplicationDto application)
        {
            var majors = application.College == null || application.College.Id == 0
                ? _programReadService.FetchMajors()
                : _programReadService.FetchMajors(application.College.Id);

            return majors;
        }

        public IEnumerable<MinorDto> FetchMinors()
        {
            return _programReadService.FetchMinors();
        }

        public void CreateApplication(ApplicationDto application)
        {
            _applicationWriteService.Create(application);
        }

        #endregion
    }
}
