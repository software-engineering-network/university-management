using System;
using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Domain.Write;

namespace UniversityManagement.Wpf.Enrollment
{
    public class SelectorViewModel<T> :
        ViewModelBase,
        ISelectorViewModel<T> where T : UniversityManagement.Domain.Read.Entity
    {
        #region Fields

        private readonly string _validationResultKey;

        private ObservableCollection<T> _items;
        private T _selectedItem;
        private IValidationResult _validationResult;

        #endregion

        #region Construction

        public SelectorViewModel(
            string labelText,
            T selectedItem,
            string validationResultKey = null
        )
        {
            LabelText = labelText;
            _selectedItem = selectedItem;
            _validationResultKey = validationResultKey;
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region ISelectorViewModel<T> Members

        public string SelectedItemValidationMessage => _validationResult.GetMessage(_validationResultKey);
        public event EventHandler SelectedItemChanged;

        public IValidationResult ValidationResult
        {
            set
            {
                _validationResult = value;

                OnPropertyChanged(nameof(SelectedItemValidationMessage));
            }
        }

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

        public string LabelText { get; }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value)
                    return;

                _selectedItem = Items.FirstOrDefault(x => x == value);
                OnPropertyChanged(nameof(SelectedItem));

                var args = new SelectedItemChangedArgs<T>
                {
                    SelectedItem = _selectedItem
                };

                SelectedItemChanged?.Invoke(this, args);
            }
        }

        #endregion
    }

    public class SelectedItemChangedArgs<T> : EventArgs
    {
        public T SelectedItem { get; set; }
    }
}
