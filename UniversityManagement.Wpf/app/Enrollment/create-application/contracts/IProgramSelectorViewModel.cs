using System.Collections.ObjectModel;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IProgramSelectorViewModel
    {
        ObservableCollection<Program> Programs { get; }
        Program SelectedProgram { get; set; }
        string SelectedProgramValidationMessage { get; }
    }
}
