using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class PersonFactory
    {
        public static Applicant CreateApplicant()
        {
            return new Applicant("John", "Doe", 1);
        }
    }
}
