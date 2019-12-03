using System;
using System.Collections.ObjectModel;

namespace UniversityManagement.Wpf
{
    public interface ISelectorViewModel<T> : IValidationResultViewModel
    {
        #region Properties

        event EventHandler<SelectedItemChangedArgs<T>> SelectedItemChanged;

        ObservableCollection<T> Items { get; set; }
        string LabelText { get; }
        T SelectedItem { get; set; }
        string SelectedItemValidationMessage { get; }

        #endregion
    }
}
