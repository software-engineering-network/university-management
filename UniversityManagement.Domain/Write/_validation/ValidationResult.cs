using System.Collections.Generic;
using FluentValidationResult = FluentValidation.Results.ValidationResult;

namespace UniversityManagement.Domain.Write
{
    public class ValidationResult : IValidationResult
    {
        private readonly Dictionary<string, string> _errors;

        public IReadOnlyDictionary<string, string> Errors => _errors;
        public bool IsValid { get; }

        public ValidationResult()
        {
            _errors = new Dictionary<string, string>();
            IsValid = true;
        }

        public ValidationResult(FluentValidationResult fluentValidationResult) : this()
        {
            foreach (var error in fluentValidationResult.Errors)
                _errors.Add(error.PropertyName, error.ErrorMessage);

            IsValid = fluentValidationResult.IsValid;
        }

        public string GetMessage(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                return null;

            return Errors.ContainsKey(propertyName)
                ? Errors[propertyName]
                : null;
        }
    }
}
