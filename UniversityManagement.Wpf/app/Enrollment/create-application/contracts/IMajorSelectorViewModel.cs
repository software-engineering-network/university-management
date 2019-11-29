using System.Collections.ObjectModel;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IMajorSelectorViewModel
    {
        ObservableCollection<ProgramDto> Programs { get; }
        ProgramDto SelectedProgram { get; set; }
    }
}
