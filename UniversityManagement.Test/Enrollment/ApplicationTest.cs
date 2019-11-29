using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Application _application;

        public ApplicationTest()
        {
            _application = ApplicationFactory.Create();
        }

        [Fact]
        public void WhenInstantiating_WithAnInvalidArgument_ThrowArgumentException()
        {
            Action createApplication = () => new Application(null);

            createApplication.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenUpdatingTheApplicant_WithExistingApplicant_ApplicantIdIsSet()
        {
            var applicant = PersonFactory.CreateApplicant();

            _application.UpdateApplicant(applicant);

            _application.ApplicantId.Should().Be(applicant.Id);
        }

        [Fact]
        public void WhenUpdatingTheApplicant_WithNullApplicant_ThrowArgumentException()
        {
            Action updateApplicant = () => _application.UpdateApplicant(null);

            updateApplicant.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenUpdatingTheApplicant_WithNonExistingApplicant_ThrowArgumentException()
        {
            var applicant = new Applicant("John", "Doe");

            Action updateApplicant = () => _application.UpdateApplicant(applicant);

            updateApplicant.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenUpdatingTheCollege_WithNullCollege_ThrowArgumentException()
        {
            Action updateCollege = () => _application.UpdateCollege(null);

            updateCollege.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenUpdatingTheMajor_WithNullMajor_ThrowArgumentException()
        {
            Action updateMajor = () => _application.UpdateMajor(null);

            updateMajor.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenUpdatingTheMajor_ItSetsCollegeIdAndMajorId()
        {
            var computerScienceMajor = ProgramFactory.CreateComputerScienceMajor();

            _application.UpdateMajor(computerScienceMajor);

            _application.CollegeId.Should().Be(3);
            _application.MajorId.Should().Be(computerScienceMajor.Id);
        }
    }
}
