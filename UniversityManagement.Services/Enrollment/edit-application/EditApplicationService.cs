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

        public IEnumerable<MajorDto> FetchMajors()
        {
            return _programReadService.Fetch();
        }

        public IEnumerable<MajorDto> FetchMajors(long collegeId)
        {
            return _programReadService.Fetch(collegeId);
        }
    }
}