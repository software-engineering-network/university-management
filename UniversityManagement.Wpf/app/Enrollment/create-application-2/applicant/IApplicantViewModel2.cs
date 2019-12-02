using System;
using UniversityManagement.Domain.Write;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IApplicantViewModel2
    {
        #region Properties

        string Name { get; set; }
        string NameValidationMessage { get; }
        string Surname { get; set; }
        string SurnameValidationMessage { get; }
        IValidationResult ValidationResult { set; }

        #endregion

        event EventHandler NameChangedHandler;
        event EventHandler SurnameChangedHandler;
    }
}
