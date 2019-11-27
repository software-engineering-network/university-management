using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Infrastructure.Memory.Read.Enrollment;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Read;
using UniversityManagement.Services.Enrollment.Write;
using UniversityManagement.Wpf.Write;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationProcessorTest
    {
        [Theory]
        [InlineData(1, 1, "John", "Doe", 3, 30, 0)]
        public void WhenCreatingApplications_WithCompleteData_ItCreatesAllApplications(
            long applicationId,
            long applicantId,
            string applicantName,
            string applicantSurname,
            long collegeId,
            long majorId,
            long minorId
        )
        {
            const long expectedId = 2;

            var applicationProcessor = TestObjectProvider.ApplicationProcessor;

            var createApplicationCommand = new CreateApplication(
                applicationId,
                applicantId,
                applicantName,
                applicantSurname,
                collegeId,
                majorId,
                minorId
            );

            applicationProcessor.CreateApplications(new[] {createApplicationCommand});

            var applicationRepository = TestObjectProvider.ApplicationRepository;
            var application = applicationRepository.Find(expectedId);

            application.Id.Should().Be(expectedId);
            application.Applicant.Id.Should().Be(applicantId);
            application.Applicant.Name.Should().Be(applicantName);
            application.Applicant.Surname.Should().Be(applicantSurname);
            application.College.Id.Should().Be(collegeId);
            application.Major.Id.Should().Be(majorId);
            application.Minor.Should().BeNull();
        }
    }
}
