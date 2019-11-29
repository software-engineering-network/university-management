using UniversityManagement.Domain;
using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class ProgramFactory
    {
        public static Program CreateComputerScienceMajor()
        {
            return new Program(30, 24, 3, ProgramType.Major);
        }
    }
}
