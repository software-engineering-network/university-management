using UniversityManagement.Domain;
using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class ProgramFactory
    {
        public static Primary CreateComputerSciencePrimary()
        {
            return new Primary(30, 3, 24, ProgramType.Major);
        }

        public static Minor CreatePhysicsMinor()
        {
            return new Minor(102, 3, 76, ProgramType.Minor);
        }
    }
}
