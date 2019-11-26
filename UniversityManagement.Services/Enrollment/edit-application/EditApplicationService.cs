using System.Collections.Generic;

namespace UniversityManagement.Services.Enrollment
{
    public class EditApplicationService : IEditApplicationService
    {
        private readonly ICollegeReadService _collegeReadService;
        private readonly IProgramReadService _programReadService;

        public EditApplicationService(
            ICollegeReadService collegeReadService,
            IProgramReadService programReadService
        )
        {
            _collegeReadService = collegeReadService;
            _programReadService = programReadService;
        }

        public IEnumerable<CollegeDto> FetchColleges()
        {
            return _collegeReadService.Fetch();
        }

        public IEnumerable<MajorDto> FetchMajors(ApplicationDto application)
        {
            var majors = application.College == null || application.College.Id == 0
                ? _programReadService.Fetch()
                : _programReadService.Fetch(application.College.Id);

            return majors;
        }
    }
}
