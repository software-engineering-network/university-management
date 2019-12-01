using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ApplicationProcessorTest
    {
        #region Fields

        private readonly IApplicationProcessor _applicationProcessor;
        private readonly TestObjectProvider _provider;

        #endregion

        #region Construction

        public ApplicationProcessorTest()
        {
            _provider = new TestObjectProvider();
            _applicationProcessor = _provider.ApplicationProcessor;
        }

        #endregion

        [Theory]
        [InlineData(null, null, null, 0)]
        [InlineData("", "", "", 0)]
        [InlineData(" ", " ", " ", 0)]
        [InlineData(" ", " ", "111-11-111", 0)]
        public void WhenValidatingACreateApplicationCommand_WithAnInvalidCommand_ItReturnsInvalid(
            string applicantName,
            string applicantSurname,
            string applicantSocialSecurityNumber,
            long programId
        )
        {
            var command = new CreateApplication(
                1,
                1,
                applicantName,
                applicantSurname,
                applicantSocialSecurityNumber,
                programId
            );

            var validationResult = _applicationProcessor.Validate(command);

            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.ContainsKey(nameof(command.ApplicantName)).Should().BeTrue();
            validationResult.Errors.ContainsKey(nameof(command.ApplicantSurname)).Should().BeTrue();
            validationResult.Errors.ContainsKey(nameof(command.ApplicantSocialSecurityNumber)).Should().BeTrue();
            validationResult.Errors.ContainsKey(nameof(command.ProgramId)).Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 1, 0, 1, "John", "Doe", "111-11-1111", 0, 30)]
        [InlineData(0, 2, 0, 2, "John", "Doe", "111-11-1112", 0, 30)]
        [InlineData(1, 1, 1, 1, "John", "Doe", "111-11-1111", 0, 30)]
        [InlineData(1, 1, 1, 1, "Jon", "Doe", "111-11-1111", 0, 30)]
        [InlineData(1, 1, 1, 1, "John", "Dough", "111-11-1111", 0, 30)]
        [InlineData(1, 1, 1, 1, "John", "Doe", "111-11-1112", 0, 30)]
        [InlineData(1, 1, 1, 1, "John", "Doe", "111-11-1111", 102, 30)]
        public void WhenCreatingAnApplication_WithValidCommands_ItCreatesAllApplications(
            long applicationId,
            long expectedId,
            long applicantId,
            long expectedApplicantId,
            string applicantName,
            string applicantSurname,
            string applicantSocialSecurityNumber,
            long minorId,
            long programId
        )
        {
            var command = new CreateApplication(
                applicationId,
                applicantId,
                applicantName,
                applicantSurname,
                applicantSocialSecurityNumber,
                programId,
                minorId
            );

            _applicationProcessor.CreateApplication(command);

            var applicationRepository = _provider.ApplicationRepository;
            var application = applicationRepository.Find(expectedId);

            application.Id.Should().Be(expectedId);
            application.Applicant.Id.Should().Be(expectedApplicantId);
            application.Applicant.Name.Should().Be(applicantName);
            application.Applicant.Surname.Should().Be(applicantSurname);
            application.Applicant.SocialSecurityNumber.Should().Be(applicantSocialSecurityNumber);
            application.Program.Id.Should().Be(programId);

            if (minorId == 0)
                application.Minor.Should().BeNull();
            else
                application.Minor.Id.Should().Be(minorId);
        }
    }
}
