namespace UniversityManagement.Infrastructure.Memory
{
    public class Application : Entity
    {
        #region Properties

        public long ApplicantId { get; set; }
        public long CollegeId { get; set; }
        public long MajorId { get; set; }
        public long MinorId { get; set; }

        #endregion

        #region Construction

        public Application(
            long id,
            long applicantId,
            long collegeId,
            long majorId,
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
