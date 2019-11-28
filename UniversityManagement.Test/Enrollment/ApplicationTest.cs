using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        [Fact]
        public void WhenUpdatingTheApplicant_ApplicantIdIsSet()
        {
            var application = new Application();
            var applicant = PersonFactory.CreateApplicant();

            application.UpdateApplicant(applicant);

            application.ApplicantId.Should().Be(applicant.Id);
        }
    }

    public class ApplicantTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenUpdatingName_WithInvalidName_ThrowsArgumentException(string name)
        {
            var applicant = PersonFactory.CreateApplicant();
            
            Action updateName = () => applicant.UpdateName(name);

            updateName.Should().Throw<ArgumentException>();
        }
    }
}
