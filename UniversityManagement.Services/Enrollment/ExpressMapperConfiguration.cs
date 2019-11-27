using ExpressMapper;
using UniversityManagement.Domain.Enrollment.Read;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Services.Enrollment
{
    public class ExpressMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Register<College, CollegeDto>();
            Mapper.Register<Major, MajorDto>();
        }
    }
}
