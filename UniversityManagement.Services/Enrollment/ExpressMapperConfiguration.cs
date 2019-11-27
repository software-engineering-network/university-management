using ExpressMapper;
using UniversityManagement.Domain.Enrollment.Read;

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
