using UniversityManagement.Domain.Write;

namespace UniversityManagement.Domain.Enrollment.Write
{
    public class Application : Entity
    {
        #region Properties

        public long ApplicantId { get; }
        public long CollegeId { get; }
        public long MajorId { get; }
        public long MinorId { get; }

        #endregion

        #region Construction

        public Application(
            long applicantId,
            long collegeId,
            long majorId,
            long id = 0,
            long minorId = 0
        ) : base(id)
        {
            ApplicantId = applicantId;
            CollegeId = collegeId;
            MajorId = majorId;
            MinorId = minorId;
        }

        #endregion
    }
}
