using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Services.Enrollment.Read
{
    public class CollegeReadService : ICollegeReadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollegeReadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CollegeDto> Fetch()
        {
            return _unitOfWork.CollegeRepository
                .Fetch()
                .Select(Mapper.Map<College, CollegeDto>);
        }
    }
}
