using System.Collections.Generic;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Services.Enrollment.Read;
using UniversityManagement.Services.Enrollment.Write;

namespace UniversityManagement.Services.Enrollment
{
    public interface IApplicationProcessor
    {
        void CreateApplications(IEnumerable<ApplicationDto> applications);
        void CreateApplications(IEnumerable<CreateApplication> commands);
    }

    public class ApplicationProcessor : IApplicationProcessor
    {
        #region Fields

        private readonly IApplicationWriteService _applicationWriteService;

        #endregion

        #region Construction

        public ApplicationProcessor(IApplicationWriteService applicationWriteService)
        {
            _applicationWriteService = applicationWriteService;
        }

        #endregion

        #region IApplicationProcessor Members

        public void CreateApplications(IEnumerable<ApplicationDto> applications)
        {
            foreach (var application in applications)
                _applicationWriteService.Create(application);
        }

        public void CreateApplications(IEnumerable<CreateApplication> commands)
        {
            foreach (var command in commands)
                _applicationWriteService.Create(command);
        }

        #endregion
    }
}
