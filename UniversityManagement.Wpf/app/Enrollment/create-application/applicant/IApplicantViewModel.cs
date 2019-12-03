using System;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IApplicantViewModel : IValidationResultViewModel
    {
        #region Properties

        event EventHandler NameChangedHandler;
        event EventHandler SocialSecurityNumberChangedHandler;
        event EventHandler SurnameChangedHandler;

        string Name { get; set; }
        string NameValidationMessage { get; }
        string SocialSecurityNumber { get; set; }
        string SocialSecurityNumberValidationMessage { get; }
        string Surname { get; set; }
        string SurnameValidationMessage { get; }

        #endregion
    }
}
