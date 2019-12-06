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
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(SocialSecurityNumber));

                _value = Regex.IsMatch(value, SocialSecurityNumberPattern)
                    ? value
                    : throw new ArgumentOutOfRangeException(
                        nameof(SocialSecurityNumber),
                        value,
                        $"\"{value}\" is not a valid social security number"
                    );
            }
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
