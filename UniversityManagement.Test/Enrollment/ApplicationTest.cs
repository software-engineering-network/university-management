using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Applicant _applicant;
        private readonly Minor _minor;
        private readonly Program _program;

        public ApplicationTest()
        {
            _applicant = PersonFactory.CreateApplicant();
            _minor = ProgramFactory.CreatePhysicsMinor();
            _program = ProgramFactory.CreateComputerScienceMajor();
        }

        [Fact]
        public void WhenInstantiating_WithNullApplicant_ThrowArgumentException()
        {
            Action createApplication = () => new Application(null, _program, _minor);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNonExistingApplicant_ThrowArgumentException()
        {
            var applicant = new Applicant("John", "Doe");

            Action createApplication = () => new Application(applicant, _program, _minor);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNullProgram_ThrowArgumentException()
        {
            Action createApplication = () => new Application(_applicant, null, _minor);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithValidArguments_AllPropertiesAreSet()
        {
            var application = new Application(_applicant, _program, _minor);

            application.ApplicantId.Should().Be(_applicant.Id);
            application.CollegeId.Should().Be(_program.CollegeId);
            application.ProgramId.Should().Be(_program.Id);
        }
    }
}
