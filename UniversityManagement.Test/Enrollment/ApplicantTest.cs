using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicantTest
    {
        private readonly Applicant _applicant;

        public ApplicantTest()
        {
            _applicant = PersonFactory.CreateApplicant();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenUpdatingName_WithInvalidName_ThrowArgumentException(string name)
        {
            Action updateName = () => _applicant.UpdateName(name);

            updateName.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenUpdatingSurname_WithInvalidSurname_ThrowArgumentException(string surname)
        {
            Action updateSurname = () => _applicant.UpdateSurname(surname);

            updateSurname.Should().Throw<ArgumentException>();
        }
    }
}
