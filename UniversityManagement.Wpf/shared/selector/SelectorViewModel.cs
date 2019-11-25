using System.Collections.ObjectModel;

namespace UniversityManagement.Wpf
{
    public abstract class SelectorViewModel<T> : 
        ViewModelBase,
        ISelectorViewModel<T>
    {
        private ObservableCollection<T> _items;
        protected T _selectedItem;

        public ObservableCollection<T> Items
        {
            get => _items;
            set
            {
                if (_items == value)
                    return;

                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public abstract T SelectedItem { get; set; }
    }
}
