using System;
using FluentAssertions;
using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Person _applicant;
        private readonly Program _computerScienceMajor;
        private readonly Minor _physicsMinor;

        public ApplicationTest()
        {
            _applicant = PersonFactory.CreatePerson();
            _physicsMinor = ProgramFactory.CreatePhysicsMinor();
            _computerScienceMajor = ProgramFactory.CreateComputerScienceMajor();
        }

        [Fact]
        public void WhenInstantiating_WithMinorInSameDisciplineAsProgram_ThrowArgumentException()
        {
            var computerScienceMinor = ProgramFactory.CreateComputerScienceMinor();

            Action createApplication = () => new Application(_applicant, _computerScienceMajor, computerScienceMinor);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNonExistingApplicant_ThrowArgumentException()
        {
            var applicant = new Person("John", "Doe", "111-11-1111");

            Action createApplication = () => new Application(applicant, _computerScienceMajor, _physicsMinor);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNullApplicant_ThrowArgumentException()
        {
            Action createApplication = () => new Application(null, _computerScienceMajor, _physicsMinor);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNullProgram_ThrowArgumentException()
        {
            Action createApplication = () => new Application(_applicant, null, _physicsMinor);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithValidArguments_AllPropertiesAreSet()
        {
            var application = new Application(_applicant, _computerScienceMajor, _physicsMinor);

            application.ApplicantId.Should().Be(_applicant.Id);
            application.CollegeId.Should().Be(_computerScienceMajor.CollegeId);
            application.ProgramId.Should().Be(_computerScienceMajor.Id);
        }
    }
}
