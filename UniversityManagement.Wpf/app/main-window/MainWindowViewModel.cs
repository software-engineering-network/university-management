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
            IApplicationReadService applicationReadService,
            IEditApplicationService editApplicationService
        )
        {
            var applicationId = 1;

            ApplicationViewModel = applicationId == 0
                ? new ApplicationViewModel(editApplicationService)
                : new ApplicationViewModel(
                    editApplicationService,
                    applicationReadService.Find(applicationId)
                );
        }

        #endregion
    }
}
