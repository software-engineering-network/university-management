using FluentAssertions;
using UniversityManagement.Domain.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Application _application;
        private readonly College _collegeOfEngineering;

        public ApplicationTest()
        {
            _collegeOfEngineering = new College("Engineering");

            var johnDoe = new Applicant("John", "Doe");
            _application = new Application(johnDoe);
        }

        [Fact]
        public void WhenSelectingACollege_TheMajorIsUnselected()
        {
            _application.SelectCollege(_collegeOfEngineering);

            _application.College.Should().Be(_collegeOfEngineering);
            _application.Major.Should().Be(null);
        }

        [Fact]
        public void WhenSelectingAMajor_ProvidedByTheSelectedCollege_TheMajorIsSelected()
        {
            var computerScience = new Major("Computer Science");

            _application
                .SelectCollege(_collegeOfEngineering)
                .SelectMajor(computerScience);

            _application.Major.Should().Be(computerScience);
        }
    }
}
