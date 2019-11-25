﻿using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Services.Enrollment
{
    public class CollegeReadService : ICollegeReadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollegeReadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CollegeDto> FetchColleges()
        {
            return _unitOfWork.CollegeRepository
                .Fetch()
                .Select(Mapper.Map<College, CollegeDto>);
        }
    }
}
