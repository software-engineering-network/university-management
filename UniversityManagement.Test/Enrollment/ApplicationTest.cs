using FluentAssertions;
using UniversityManagement.Domain.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        [Fact]
        public void WhenSelectingACollege_TheMajorIsUnselected()
        {
            var johnDoe = new Applicant("John", "Doe");
            var collegeOfEngineering = new College("Engineering");
            var application = new Application(johnDoe);

            application.SelectCollege(collegeOfEngineering);

            application.College.Should().Be(collegeOfEngineering);
            application.Major.Should().Be(null);
        }
    }
}
