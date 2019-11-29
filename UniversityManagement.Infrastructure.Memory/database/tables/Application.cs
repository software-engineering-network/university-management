namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class Application : Entity
    {
        #region Properties

        public long ApplicantId { get; set; }
        public long CollegeId { get; set; }
        public long MinorId { get; set; }
        public long ProgramId { get; set; }

        #endregion

        #region Construction

        public Application()
        {
        }

        public Application(
            long id,
            long applicantId,
            long collegeId,
            long programId,
            long minorId = 0
        ) : base(id)
        {
            ApplicantId = applicantId;
            CollegeId = collegeId;
            MinorId = minorId;
            ProgramId = programId;
        }

        #endregion
    }
}
