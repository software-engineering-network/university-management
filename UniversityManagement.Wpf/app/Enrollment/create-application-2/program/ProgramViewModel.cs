using System;
using System.Collections.ObjectModel;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Domain.Write;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ProgramViewModel :
        ViewModelBase,
        IProgramViewModel
    {
        #region Fields

        private ObservableCollection<Program> _programs;
        private Program _selectedProgram;
        private IValidationResult _validationResult;

        #endregion

        #region Construction

        public ProgramViewModel(Program selectedProgram)
        {
            _selectedProgram = selectedProgram;
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region IProgramViewModel Members

        public string SelectedProgramValidationMessage => _validationResult.GetMessage("ProgramId");

        public IValidationResult ValidationResult
        {
            set
            {
                _validationResult = value;

                OnPropertyChanged(nameof(SelectedProgramValidationMessage));
            }
        }

        public event EventHandler SelectedProgramChanged;

        public ObservableCollection<Program> Programs
        {
            get => _programs;
            private set
            {
                if (_programs == value)
                    return;

                _programs = value;
                OnPropertyChanged(nameof(Programs));
            }
        }

        public Program SelectedProgram
        {
            get => _selectedProgram;
            set
            {
                if (_selectedProgram == value)
                    return;

                _selectedProgram = value;
                OnPropertyChanged(nameof(SelectedProgram));
                SelectedProgramChanged?.Invoke(this, null);
            }
        }

        #endregion
    }
}
