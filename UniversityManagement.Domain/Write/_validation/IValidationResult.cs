using System.Collections.Generic;

namespace UniversityManagement.Domain.Write
{
    public interface IValidationResult
    {
        IReadOnlyDictionary<string, string> Errors { get; }
        bool IsValid { get; }

        string GetMessage(string propertyName);
    }
}
