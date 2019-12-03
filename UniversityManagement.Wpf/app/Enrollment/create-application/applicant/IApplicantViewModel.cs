using System;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IApplicantViewModel : IValidationResultViewModel
    {
        #region Properties

        event EventHandler NameChanged;
        event EventHandler SocialSecurityNumberChanged;
        event EventHandler SurnameChanged;

        string Name { get; set; }
        string NameValidationMessage { get; }
        string SocialSecurityNumber { get; set; }
        string SocialSecurityNumberValidationMessage { get; }
        string Surname { get; set; }
        string SurnameValidationMessage { get; }

        #endregion
    }
}
