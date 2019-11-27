﻿using System.Collections.Generic;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Services.Enrollment
{
    public interface IEditApplicationService
    {
        IEnumerable<CollegeDto> FetchColleges();
        IEnumerable<MajorDto> FetchMajors(ApplicationDto application);
        IEnumerable<MinorDto> FetchMinors();

        void CreateApplication(ApplicationDto application);
    }
}
