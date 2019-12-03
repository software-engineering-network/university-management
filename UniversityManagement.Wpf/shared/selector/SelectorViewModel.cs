using System;
using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Domain.Write;
using Entity = UniversityManagement.Domain.Read.Entity;

namespace UniversityManagement.Wpf
{
    public class SelectorViewModel<T> :
        ViewModelBase,
        ISelectorViewModel<T> where T : Entity
    {
        #region Fields

        private readonly string _validationResultKey;

        private ObservableCollection<T> _items;
        private T _selectedItem;
        private IValidationResult _validationResult;

        #endregion

        #region Construction

        public SelectorViewModel(
            T selectedItem = null,
            string labelText = null,
            string validationResultKey = null
        )
        {
            _selectedItem = selectedItem;

            LabelText = labelText != null
                ? $"{labelText}:"
                : null;

            _validationResultKey = validationResultKey;
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region ISelectorViewModel<T>

        public event EventHandler<SelectedItemChangedArgs<T>> SelectedItemChanged;

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

        public string SelectedItemValidationMessage => _validationResult.GetMessage(_validationResultKey);

        public IValidationResult ValidationResult
        {
            set
            {
                _validationResult = value;

                OnPropertyChanged(nameof(SelectedItemValidationMessage));
            }
        }

        #endregion
    }
}
