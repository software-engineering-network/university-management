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
}
