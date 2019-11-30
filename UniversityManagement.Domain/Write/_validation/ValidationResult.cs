using System.Collections.Generic;
using FluentValidationResult = FluentValidation.Results.ValidationResult;

namespace UniversityManagement.Domain.Write
{
    public class ValidationResult : IValidationResult
    {
        private readonly Dictionary<string, string> _errors;

        public IReadOnlyDictionary<string, string> Errors => _errors;
        public bool IsValid { get; }

        public ValidationResult(FluentValidationResult fluentValidationResult)
        {
            _errors = new Dictionary<string, string>();

            foreach (var error in fluentValidationResult.Errors)
                _errors.Add(error.PropertyName, error.ErrorMessage);

            IsValid = fluentValidationResult.IsValid;
        }
    }
}
