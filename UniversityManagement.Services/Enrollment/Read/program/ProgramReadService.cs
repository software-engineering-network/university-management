using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Services.Enrollment.Read
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

        public IEnumerable<ProgramDto> FetchPrograms()
        {
            var majors = _unitOfWork.MajorRepository
                .Fetch()
                .Select(Mapper.Map<Program, ProgramDto>)
                .ToList();

            return majors;
        }

        public IEnumerable<ProgramDto> FetchPrograms(long collegeId)
        {
            var majors = _unitOfWork.MajorRepository
                .Fetch(collegeId)
                .Select(Mapper.Map<Program, ProgramDto>)
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
