using System.Collections.ObjectModel;

namespace UniversityManagement.Wpf
{
    public interface ISelectorViewModel<T>
    {
        ObservableCollection<T> Items { get; }
        T SelectedItem { get; set; }
    }
}
