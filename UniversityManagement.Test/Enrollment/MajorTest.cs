using System;
using FluentAssertions;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class PrimaryTest
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
            Action createPrimary = () => new Program(id, disciplineId, collegeId, programType);

            createPrimary.Should().Throw<ArgumentException>();
        }
    }
}
