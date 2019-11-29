﻿using ExpressMapper;
using UniversityManagement.Domain.Read;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Services.Enrollment.Read
{
    public class ApplicationReadService : IApplicationReadService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public ApplicationReadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IApplicationReadService Members

        public ApplicationDto Find(long id)
        {
            var application = _unitOfWork.ApplicationRepository.Find(id);
            var dto = new ApplicationDto
            {
                Id = application.Id,
                Applicant = Mapper.Map<Applicant, ApplicantDto>(application.Applicant),
                College = Mapper.Map<College, CollegeDto>(application.College),
                Minor = Mapper.Map<Minor, MinorDto>(application.Minor),
                Program = Mapper.Map<Program, ProgramDto>(application.Program)
            };

            dto.Program.College = Mapper.Map<College, CollegeDto>(application.College);

            return dto;
        }

        #endregion
    }
}
