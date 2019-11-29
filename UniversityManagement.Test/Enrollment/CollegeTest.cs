using System;
using FluentAssertions;
using UniversityManagement.Domain.Read.Enrollment;
using Xunit;

namespace UniversityManagement.Test.Enrollment
{
    public class CollegeTest
    {
        [Theory]
        [InlineData(0, "Arts & Sciences")]
        [InlineData(1, null)]
        [InlineData(1, "")]
        [InlineData(1, " ")]
        public void WhenInstantiating_WithAnInvalidArgument_ThrowArgumentException(long id, string name)
        {
            Action createCollege = () => new College(id, name);

            createCollege.Should().Throw<ArgumentException>();
        }
    }
}
