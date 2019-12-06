using System;
using FluentAssertions;
using UniversityManagement.Domain.Write;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class SocialSecurityNumberTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenInstantiating_WithNullOrWhitespaceValue_ThrowArgumentException(string value)
        {
            Action createSocialSecurityNumber = () => new SocialSecurityNumber(value);

            createSocialSecurityNumber.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("111111111")]
        public void WhenInstantiating_WithAnInvalidArgument_ThrowArgumentException(string value)
        {
            Action createSocialSecurityNumber = () => new SocialSecurityNumber(value);

            createSocialSecurityNumber.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData("111-11-1111")]
        public void WhenInstantiating_WithAValidArgument_ValueIsSet(string value)
        {
            var socialSecurityNumber = new SocialSecurityNumber(value);

            socialSecurityNumber.Value.Should().Be("111-11-1111");
        }
    }
}
