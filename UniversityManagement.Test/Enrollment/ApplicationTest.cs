using FluentAssertions;
using UniversityManagement.Domain.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Applicant _johnDoe;
        private readonly Application _application;
        private readonly College _collegeOfEngineering;

        public ApplicationTest()
        {
            _johnDoe = CreateApplicant();
            _application = CreateApplication(_johnDoe);
            _collegeOfEngineering = new College("Engineering");
        }

        [Fact]
        public void WhenCreatingAnApplication_TheApplicantIsSet()
        {
            _application.Applicant.Should().Be(_johnDoe);
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

        private static Applicant CreateApplicant()
        {
            return new Applicant("John", "Doe");
        }

        private static Application CreateApplication(Applicant applicant)
        {
            return new Application(applicant);
        }
    }
}
