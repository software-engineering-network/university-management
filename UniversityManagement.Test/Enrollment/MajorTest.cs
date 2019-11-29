using System;
using FluentAssertions;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class ProgramTest
    {
        [Theory]
        [InlineData(0, 1, 1, ProgramType.Major)]
        [InlineData(1, 0, 1, ProgramType.Major)]
        [InlineData(1, 1, 0, ProgramType.Major)]
        [InlineData(1, 1, 1, ProgramType.None)]
        [InlineData(1, 1, 1, ProgramType.Concentration)]
        [InlineData(1, 1, 1, ProgramType.Minor)]
        public void WhenInstantiating_WithAnInvalidArgument_ThrowArgumentException(long id, long disciplineId, long collegeId, ProgramType programType)
        {
            Action createMajor = () => new Program(id, disciplineId, collegeId, programType);

            createMajor.Should().Throw<ArgumentException>();
        }
    }
}
