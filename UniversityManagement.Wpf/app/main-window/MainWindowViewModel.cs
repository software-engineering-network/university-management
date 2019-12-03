using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Wpf.Enrollment;

namespace UniversityManagement.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Properties

        public ApplicationViewModel ApplicationViewModel { get; }

        public string Title => "University Management";

        #endregion

        #region Construction

        public MainWindowViewModel(
            IApplicationRepository applicationRepository,
            ICreateApplicationService createApplicationService
        )
        {
            const long applicationId = 0;

            ApplicationViewModel = applicationId == 0
                ? new ApplicationViewModel(createApplicationService)
                : new ApplicationViewModel(
                    createApplicationService,
                    applicationRepository.Find(applicationId)
                );
        }

        #endregion
    }
}
