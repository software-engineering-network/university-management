using System;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Domain.Write;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicantViewModel :
        ViewModelBase,
        IApplicantViewModel2
    {
        #region Fields

        private Applicant _applicant;
        private IValidationResult _validationResult;

        #endregion

        #region Properties

        private Applicant Applicant
        {
            set
            {
                _applicant = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Surname));
                OnPropertyChanged(nameof(SocialSecurityNumber));
            }
        }

        #endregion

        #region Construction

        public ApplicantViewModel(Applicant applicant)
        {
            Applicant = applicant;
            _validationResult = new ValidationResult();
        }

        #endregion

        #region IApplicantViewModel2 Members

        public string Name
        {
            get => _applicant.Name;
            set
            {
                if (Name == value)
                    return;

                _applicant.Name = value;
                OnPropertyChanged(nameof(Name));
                NameChangedHandler?.Invoke(this, null);
            }
        }



        public string Surname
        {
            get => _applicant.Surname;
            set
            {
                if (Surname == value)
                    return;

                _applicant.Surname = value;
                OnPropertyChanged(nameof(Surname));
                SurnameChangedHandler?.Invoke(this, null);
            }
        }

        public string SocialSecurityNumber
        {
            get => _applicant.SocialSecurityNumber;
            set
            {
                if (SocialSecurityNumber == value)
                    return;

                _applicant.SocialSecurityNumber = value;
                OnPropertyChanged(nameof(SocialSecurityNumber));
                SocialSecurityNumberChangedHandler?.Invoke(this, null);
            }
        }

        public event EventHandler NameChangedHandler;
        public event EventHandler SurnameChangedHandler;
        public event EventHandler SocialSecurityNumberChangedHandler;

        public string NameValidationMessage => _validationResult.GetMessage("ApplicantName");
        public string SurnameValidationMessage => _validationResult.GetMessage("ApplicantSurname");
        public string SocialSecurityNumberValidationMessage => _validationResult.GetMessage("ApplicantSocialSecurityNumber");

        public IValidationResult ValidationResult
        {
            set
            {
                _validationResult = value;
                OnPropertyChanged(nameof(NameValidationMessage));
                OnPropertyChanged(nameof(SurnameValidationMessage));
                OnPropertyChanged(nameof(SocialSecurityNumberValidationMessage));
            }
        }

        #endregion
    }
}
