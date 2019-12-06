using System;
using System.Text.RegularExpressions;

namespace UniversityManagement.Domain.Write
{
    public class SocialSecurityNumber
    {
        #region Fields

        private const string SocialSecurityNumberPattern = @"^\d{3}-\d{2}-\d{4}$";
        private string _value;

        #endregion

        #region Properties

        public string Value
        {
            get => _value;
            private set => _value = Regex.IsMatch(value, SocialSecurityNumberPattern)
                ? value
                : throw new ArgumentException();
        }

        #endregion

        #region Construction

        public SocialSecurityNumber(string socialSecurityNumber)
        {
            Value = socialSecurityNumber;
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
