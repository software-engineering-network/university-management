using System;
using System.Collections.ObjectModel;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface ISelectorViewModel<T> : IValidationResultViewModel
    {
        #region Properties

        ObservableCollection<T> Items { get; }
        string LabelText { get; }
        T SelectedItem { get; set; }
        string SelectedItemValidationMessage { get; }

        #endregion

        event EventHandler SelectedItemChanged;
    }
}
