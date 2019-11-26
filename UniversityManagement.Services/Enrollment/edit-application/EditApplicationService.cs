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

        public bool SetApplicantName(ApplicationDto application, string name)
        {
            if (application.Applicant.Name == name)
                return false;

            application.Applicant.Name = name;
            return true;
        }

        public bool SetApplicantSurname(ApplicationDto application, string surname)
        {
            if (application.Applicant.Surname == surname)
                return false;

            application.Applicant.Surname = surname;
            return true;
        }

        public bool SetCollege(ApplicationDto application, CollegeDto college)
        {
            if (application.College == college)
                return false;

            application.College = college;
            return true;
        }

        public bool SetMajor(ApplicationDto application, MajorDto major)
        {
            if (application.Major == major)
                return false;

            application.Major = major;
            return true;
        }
    }
}