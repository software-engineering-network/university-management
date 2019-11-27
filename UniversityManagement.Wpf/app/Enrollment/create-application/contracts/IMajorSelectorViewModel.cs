using System.Collections.ObjectModel;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IMajorSelectorViewModel
    {
        ObservableCollection<MajorDto> Majors { get; }
        MajorDto SelectedMajor { get; set; }
    }
}
