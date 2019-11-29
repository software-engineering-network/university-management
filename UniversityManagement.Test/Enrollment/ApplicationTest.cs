using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Applicant _applicant;
        private readonly Major _major;

        public ApplicationTest()
        {
            _applicant = PersonFactory.CreateApplicant();
            _major = ProgramFactory.CreateComputerScienceMajor();
        }

        [Fact]
        public void WhenInstantiating_WithNullApplicant_ThrowArgumentException()
        {
            Action createApplication = () => new Application(null, _major);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenInstantiating_WithNonExistingApplicant_ThrowArgumentException()
        {
            var applicant = new Applicant("John", "Doe");

            Action createApplication = () => new Application(applicant, _major);

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
            var application = new Application(_applicant, _major);

            application.ApplicantId.Should().Be(_applicant.Id);
            application.CollegeId.Should().Be(_major.CollegeId);
            application.MajorId.Should().Be(_major.Id);
        }
    }
}
