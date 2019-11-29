using System;
using FluentAssertions;
using UniversityManagement.Domain.Write.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class MajorTest
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        public void WhenInstantiating_WithAnInvalidArgument_ThrowArgumentException(long id, long disciplineId, long collegeId)
        {
            Action createMajor = () => new Major(id, disciplineId, collegeId);

            createMajor.Should().Throw<ArgumentException>();
        }
    }
}
