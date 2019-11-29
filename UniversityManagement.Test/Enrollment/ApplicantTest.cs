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
        [InlineData(null, "Doe")]
        [InlineData("", "Doe")]
        [InlineData(" ", "Doe")]
        [InlineData("John", null)]
        [InlineData("John", "")]
        [InlineData("John", " ")]
        public void WhenInstantiating_WithAnInvalidArgument_ThrowArgumentException(string name, string surname)
        {
            Action createApplicant = () => new Applicant(name, surname);

            createApplicant.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("John", "Doe")]
        public void WhenInstantiating_WithValidArguments_AllPropertiesAreSet(string name, string surname)
        {
            var applicant = new Applicant(name, surname);

            applicant.Name.Should().Be(name);
            applicant.Surname.Should().Be(surname);
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
        [InlineData("Jon")]
        public void WhenUpdatingName_WithValidName_NameIsSet(string name)
        {
            _applicant.UpdateName(name);

            _applicant.Name.Should().Be(name);
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

        [Theory]
        [InlineData("Dough")]
        public void WhenUpdatingSurname_WithValidSurname_SurnameIsSet(string surname)
        {
            _applicant.UpdateSurname(surname);

            _applicant.Surname.Should().Be(surname);
        }
    }
}
