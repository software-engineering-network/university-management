using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment.Write;

namespace UniversityManagement.Services.Enrollment.Write
{
    public class ApplicationWriteService : IApplicationWriteService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public ApplicationWriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IApplicationWriteService Members

        public void CreateApplication(CreateApplication command)
        {
            var application = new Application(
                command.ApplicantId,
                command.CollegeId,
                command.MajorId,
                command.ApplicationId,
                command.MinorId
            );
        }

        #endregion
    }
}
