using UniversityManagement.Wpf.Enrollment;

namespace UniversityManagement.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ApplicationViewModel ApplicationViewModel { get; }

        public string Title => "University Management";

        public MainWindowViewModel(ApplicationViewModel applicationViewModel)
        {
            ApplicationViewModel = applicationViewModel;
        }
    }
}
