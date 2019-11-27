using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment.Write;

namespace UniversityManagement.Services.Enrollment.Write
{
    public interface IApplicationWriteService
    {
        void CreateApplication(CreateApplication command);
    }

    public class ApplicationWriteService : IApplicationWriteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationWriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
    }
}
