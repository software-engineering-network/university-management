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
        [InlineData(1, 1, "John", "Doe", 0, 30)]
        [InlineData(1, 1, "John", "Doe", 102, 30)]
        //[InlineData(1, 1, "John", "Doe", 0, 0, 68)]
        public void WhenCreatingApplications_ItCreatesAllApplications(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long minorId,
            long programId
        )
        {
            const long expectedId = 2;

            var applicationProcessor = _provider.ApplicationProcessor;

            var createApplicationCommand = new CreateApplication(
                applicationId,
                applicantId,
                applicantName,
                applicantSurname,
                programId,
                minorId
            );

            applicationProcessor.CreateApplications(new[] {createApplicationCommand});

            var applicationRepository = _provider.ApplicationRepository;
            var application = applicationRepository.Find(expectedId);

            application.Id.Should().Be(expectedId);
            application.Applicant.Id.Should().Be(applicantId);
            application.Applicant.Name.Should().Be(applicantName);
            application.Applicant.Surname.Should().Be(applicantSurname);
            application.Program.Id.Should().Be(programId);

            if (minorId == 0)
                application.Minor.Should().BeNull();
            else
                application.Minor.Id.Should().Be(minorId);
        }
    }
}
