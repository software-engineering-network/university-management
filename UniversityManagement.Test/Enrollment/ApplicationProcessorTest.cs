using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationProcessorTest
    {
        #region Fields

        private readonly TestObjectProvider _provider;

        #endregion

        #region Construction

        public ApplicationProcessorTest()
        {
            _provider = new TestObjectProvider();
        }

        #endregion

        [Theory]
        [InlineData(1, 1, "John", "Doe", 30, 0, 30)]
        //[InlineData(1, 1, "John", "Doe", 0, 0, 68)]
        public void WhenCreatingApplications_ItCreatesAllApplications(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long majorId,
            long minorId,
            long expectedMajorId
        )
        {
            const long expectedId = 2;

            var applicationProcessor = _provider.ApplicationProcessor;

            var createApplicationCommand = new CreateApplication(
                applicationId,
                applicantId,
                applicantName,
                applicantSurname,
                majorId,
                minorId
            );

            applicationProcessor.CreateApplications(new[] {createApplicationCommand});

            var applicationRepository = _provider.ApplicationRepository;
            var application = applicationRepository.Find(expectedId);

            application.Id.Should().Be(expectedId);
            application.Applicant.Id.Should().Be(applicantId);
            application.Applicant.Name.Should().Be(applicantName);
            application.Applicant.Surname.Should().Be(applicantSurname);
            application.Major.Id.Should().Be(expectedMajorId);
            application.Minor.Should().BeNull();
        }
    }
}
