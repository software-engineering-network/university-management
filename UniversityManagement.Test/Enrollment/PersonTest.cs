using System;
using FluentAssertions;
using UniversityManagement.Domain.Write;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class PersonTest
    {
        private readonly Person _person;

        public PersonTest()
        {
            _person = PersonFactory.CreatePerson();
        }

        [Theory]
        [InlineData(null, "Doe", "111-11-1111")]
        [InlineData("", "Doe", "111-11-1111")]
        [InlineData(" ", "Doe", "111-11-1111")]
        [InlineData("John", null, "111-11-1111")]
        [InlineData("John", "", "111-11-1111")]
        [InlineData("John", " ", "111-11-1111")]
        [InlineData("John", "Doe", "111-11-111")]
        public void WhenInstantiating_WithAnInvalidArgument_ThrowArgumentException(
            string name, 
            string surname, 
            string socialSecurityNumber
        )
        {
            Action createApplicant = () => new Person(name, surname, socialSecurityNumber);

            createApplicant.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("John", "Doe", "111-11-1111")]
        public void WhenInstantiating_WithValidArguments_AllPropertiesAreSet(
            string name, 
            string surname, 
            string socialSecurityNumber
        )
        {
            var applicant = new Person(name, surname, socialSecurityNumber);

            applicant.Name.Should().Be(name);
            applicant.Surname.Should().Be(surname);
            applicant.SocialSecurityNumber.Value.Should().Be(socialSecurityNumber);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenSettingName_WithInvalidName_ThrowArgumentException(string name)
        {
            Action updateName = () => _person.Name = name;

            updateName.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("Jon")]
        public void WhenUpdatingName_WithValidName_NameIsSet(string name)
        {
            _person.Name = name;

            _person.Name.Should().Be(name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenSettingSurname_WithInvalidSurname_ThrowArgumentException(string surname)
        {
            Action updateSurname = () => _person.Surname = surname;

            updateSurname.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("Dough")]
        public void WhenSettingSurname_WithValidSurname_SurnameIsSet(string surname)
        {
            _person.Surname = surname;

            _person.Surname.Should().Be(surname);
        }
    }
}
