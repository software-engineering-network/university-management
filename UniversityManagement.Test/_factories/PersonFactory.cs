using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class PersonFactory
    {
        public static Applicant CreateApplicant()
        {
            return new Applicant(1, "John", "Doe");
        }
    }

    public class ProgramFactory
    {
        public static Major CreateComputerScienceMajor()
        {
            return new Major(30, 24, 3);
        }
    }
}
