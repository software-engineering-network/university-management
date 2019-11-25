using UniversityManagement.Wpf.Enrollment;

namespace UniversityManagement.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {
        public CreateApplicationViewModel CreateApplicationViewModel { get; }
        public string Title => "University Management";

        public MainWindowViewModel(CreateApplicationViewModel createApplicationViewModel)
        {
            CreateApplicationViewModel = createApplicationViewModel;
        }
    }
}
