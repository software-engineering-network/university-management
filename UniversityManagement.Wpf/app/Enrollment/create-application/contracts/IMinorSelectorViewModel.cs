using System.Collections.ObjectModel;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IMinorSelectorViewModel
    {
        ObservableCollection<MinorDto> Minors { get; }
        MinorDto SelectedMinor { get; set; }
    }
}
