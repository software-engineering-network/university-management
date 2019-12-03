using System;
using System.Collections.ObjectModel;
using UniversityManagement.Wpf.Enrollment;

namespace UniversityManagement.Wpf
{
    public interface ISelectorViewModel<T> : IValidationResultViewModel
    {
        #region Properties

        ObservableCollection<T> Items { get; set; }
        string LabelText { get; }
        T SelectedItem { get; set; }
        string SelectedItemValidationMessage { get; }

        #endregion

        event EventHandler SelectedItemChanged;
    }
}
