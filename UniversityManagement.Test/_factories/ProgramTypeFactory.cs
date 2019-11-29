using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class ProgramTypeFactory
    {
        public static ProgramType CreateMajor()
        {
            return new ProgramType(3, "Major");
        }

        public static ProgramType CreateMinor()
        {
            return new ProgramType(4, "Minor");
        }
    }
}
