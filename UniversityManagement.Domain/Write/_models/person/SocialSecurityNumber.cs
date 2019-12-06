using System;
using System.Text.RegularExpressions;

namespace UniversityManagement.Domain.Write
{
    public class SocialSecurityNumber
    {
        #region Fields

        private const string SocialSecurityNumberPattern = @"^\d{3}-\d{2}-\d{4}$";

        #endregion

        #region Properties

        public string Value { get; }

        #endregion

        #region Construction

        public SocialSecurityNumber(string socialSecurityNumber)
        {
            Value = Regex.IsMatch(socialSecurityNumber, SocialSecurityNumberPattern)
                ? socialSecurityNumber
                : throw new ArgumentException();
        }

        #endregion

        #region object Overrides

        public override string ToString()
        {
            return Value;
        }

        #endregion
    }
}
