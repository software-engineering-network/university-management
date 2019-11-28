using System.Collections.Generic;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public interface IApplicationProcessor
    {
        void CreateApplication(CreateApplication command);
        void CreateApplications(IEnumerable<CreateApplication> commands);
    }
}
