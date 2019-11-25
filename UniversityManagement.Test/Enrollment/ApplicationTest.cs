using System;
using FluentAssertions;
using UniversityManagement.Domain.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationTest
    {
        private readonly Application _application;
        private readonly College _collegeOfEngineering;
        private readonly College _collegeOfPharmacy;
        private readonly Major _computerScience;
        private readonly Applicant _johnDoe;

        public ApplicationTest()
        {
            _johnDoe = TestObjectFactory.CreateJohnDoe();
            _application = new Application(_johnDoe);
            _collegeOfEngineering = TestObjectFactory.CreateCollegeOfEngineering();
            _collegeOfPharmacy = TestObjectFactory.CreateCollegeOfPharmacy();
            _computerScience = TestObjectFactory.CreateComputerScience();
        }

        [Fact]
        public void WhenCreatingAnApplication_TheApplicantIsSet()
        {
            _application.Applicant.Should().Be(_johnDoe);
        }

        [Fact]
        public void WhenSelectingACollege_TheMajorIsUnselected()
        {
            _application
                .SelectCollege(_collegeOfEngineering)
                .SelectMajor(_computerScience)
                .SelectCollege(_collegeOfPharmacy);

            _application.College.Should().Be(_collegeOfPharmacy);
            _application.Major.Should().Be(null);
        }

        [Fact]
        public void WhenSelectingAMajor_ProvidedByTheSelectedCollege_TheMajorIsSelected()
        {
            var computerScience = TestObjectFactory.CreateComputerScience();

            _application
                .SelectCollege(_collegeOfEngineering)
                .SelectMajor(computerScience);

            _application.Major.Should().Be(computerScience);
        }

        [Fact]
        public void WhenSelectingAMajor_NotProvidedByTheSelectedCollege_AnArgumentExceptionIsThrown()
        {
            _application.SelectCollege(_collegeOfEngineering);
            var pharmacy = TestObjectFactory.CreatePharmacyMajor();

            Action selectPharmacy = () => _application.SelectMajor(pharmacy);

            selectPharmacy.Should().Throw<ArgumentException>();
        }
    }
}
