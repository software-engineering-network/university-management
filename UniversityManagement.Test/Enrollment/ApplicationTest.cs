using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Applicant _applicant;
        private readonly Program _program;

        public ApplicationTest()
        {
            _applicant = PersonFactory.CreateApplicant();
            _program = ProgramFactory.CreateComputerScienceMajor();
        }

        [Fact]
        public void WhenInstantiating_WithNullApplicant_ThrowArgumentException()
        {
            Action createApplication = () => new Application(null, _program);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNonExistingApplicant_ThrowArgumentException()
        {
            var applicant = new Applicant("John", "Doe");

            Action createApplication = () => new Application(applicant, _program);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNullMajor_ThrowArgumentException()
        {
            Action createApplication = () => new Application(_applicant, null);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithValidArguments_AllPropertiesAreSet()
        {
            var application = new Application(_applicant, _program);

            application.ApplicantId.Should().Be(_applicant.Id);
            application.CollegeId.Should().Be(_program.CollegeId);
            application.MajorId.Should().Be(_program.Id);
        }
    }
}
