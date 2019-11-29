using UniversityManagement.Domain;
using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class ProgramFactory
    {
        public static Program CreateComputerScienceMajor()
        {
            return new Program(30, 3, 24, ProgramType.Major);
        }

        public static Minor CreateComputerScienceMinor()
        {
            return new Minor(31, 3, 24, ProgramType.Minor);
        }

        public static Minor CreatePhysicsMinor()
        {
            return new Minor(102, 3, 76, ProgramType.Minor);
        }
    }
}
