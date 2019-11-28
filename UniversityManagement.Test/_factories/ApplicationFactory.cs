using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Test
{
    public class ApplicationFactory
    {
        public static Application Create()
        {
            var applicant = PersonFactory.CreateApplicant();

            return new Application(applicant);
        }
    }
}
