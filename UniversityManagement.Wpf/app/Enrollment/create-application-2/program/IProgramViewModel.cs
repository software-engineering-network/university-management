using System;
using System.Collections.ObjectModel;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IProgramViewModel : IValidationResultViewModel
    {
        #region Properties

        ObservableCollection<Program> Programs { get; }
        Program SelectedProgram { get; set; }
        string SelectedProgramValidationMessage { get; }

        #endregion

        event EventHandler SelectedProgramChanged;
    }
}
