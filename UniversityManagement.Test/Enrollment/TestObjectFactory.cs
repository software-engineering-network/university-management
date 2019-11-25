using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Test.Enrollment
{
    public class TestObjectFactory
    {
        public static College CreateCollegeOfEngineering()
        {
            return new College(
                "Engineering",
                1
            );
        }

        public static College CreateCollegeOfPharmacy()
        {
            return new College(
                "Pharmacy",
                2
            );
        }

        public static Major CreateComputerScience()
        {
            return new Major(
                "Computer Science",
                CreateCollegeOfEngineering()
            );
        }

        public static Applicant CreateJohnDoe()
        {
            return new Applicant("John", "Doe");
        }

        public static Major CreatePharmacyMajor()
        {
            return new Major(
                "Pharmacy",
                CreateCollegeOfPharmacy()
            );
        }
    }
}
