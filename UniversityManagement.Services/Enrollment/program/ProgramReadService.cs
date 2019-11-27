using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment.Read;

namespace UniversityManagement.Services.Enrollment
{
    public class ProgramReadService : IProgramReadService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public ProgramReadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IProgramReadService Members

        public IEnumerable<MajorDto> FetchMajors()
        {
            var majors = _unitOfWork.MajorRepository
                .Fetch()
                .Select(Mapper.Map<Major, MajorDto>)
                .ToList();

            return majors;
        }

        public IEnumerable<MajorDto> FetchMajors(long collegeId)
        {
            var majors = _unitOfWork.MajorRepository
                .Fetch(collegeId)
                .Select(Mapper.Map<Major, MajorDto>)
                .ToList();

            return majors;
        }

        public IEnumerable<MinorDto> FetchMinors()
        {
            var minors = _unitOfWork.MinorRepository
                .Fetch()
                .Select(Mapper.Map<Minor, MinorDto>)
                .ToList();

            return minors;
        }

        #endregion
    }
}
