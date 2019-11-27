using UniversityManagement.Domain.Read;

namespace UniversityManagement.Domain.Enrollment.Read
{
    public class Applicant : Entity
    {
        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }

        #endregion
    }
}
