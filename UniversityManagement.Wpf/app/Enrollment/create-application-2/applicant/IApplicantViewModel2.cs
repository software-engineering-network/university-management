using System;
using UniversityManagement.Domain.Write;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IApplicantViewModel2 : IValidationResultViewModel
    {
        #region Properties

        string Name { get; set; }
        string NameValidationMessage { get; }
        string Surname { get; set; }
        string SurnameValidationMessage { get; }
        string SocialSecurityNumber { get; set; }
        string SocialSecurityNumberValidationMessage { get; }

        #endregion

        event EventHandler NameChangedHandler;
        event EventHandler SurnameChangedHandler;
        event EventHandler SocialSecurityNumberChangedHandler;
    }
}
