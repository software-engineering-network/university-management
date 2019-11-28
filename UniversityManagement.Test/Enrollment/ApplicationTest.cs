using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        [Fact]
        public void WhenUpdatingTheApplicant_WithExistingApplicant_ApplicantIdIsSet()
        {
            var application = new Application();
            var applicant = PersonFactory.CreateApplicant();

            application.UpdateApplicant(applicant);

            application.ApplicantId.Should().Be(applicant.Id);
        }

        [Fact]
        public void WhenUpdatingTheApplicant_WithNullApplicant_ThrowArgumentException()
        {
            var application = new Application();

            Action updateApplicant = () => application.UpdateApplicant(null);

            updateApplicant.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenUpdatingTheApplicant_WithNonExistingApplicant_ThrowArgumentException()
        {
            var application = new Application();
            var applicant = new Applicant("John", "Doe");

            Action updateApplicant = () => application.UpdateApplicant(applicant);

            updateApplicant.Should().Throw<ArgumentException>();
        }
    }
}
