using System;
using System.Text.RegularExpressions;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class SocialSecurityNumber
    {
        private const string Pattern = @"^\d{3}-\d{2}-\d{4}$";

        public string Value { get; }

        public SocialSecurityNumber(string socialSecurityNumber)
        {
            if (!IsValid(socialSecurityNumber))
                throw new ArgumentException();

            Value = socialSecurityNumber;
        }

        private static bool IsValid(string socialSecurityNumber)
        {
            return Regex.IsMatch(socialSecurityNumber, Pattern);
        }
    }
}
