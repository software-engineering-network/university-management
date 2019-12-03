using System;
using System.Text.RegularExpressions;

namespace UniversityManagement.Domain.Write
{
    public class SocialSecurityNumber
    {
        private const string Pattern = @"^\d{3}-\d{2}-\d{4}$";

        #region Properties

        public string Value { get; }

        #endregion

        #region Construction

        public SocialSecurityNumber(string socialSecurityNumber)
        {
            if (!IsValid(socialSecurityNumber))
                throw new ArgumentException();

            Value = socialSecurityNumber;
        }

        #endregion

        #region object Overrides

        public override string ToString()
        {
            return Value;
        }

        #endregion

        private static bool IsValid(string socialSecurityNumber)
        {
            return Regex.IsMatch(socialSecurityNumber, Pattern);
        }
    }
}
