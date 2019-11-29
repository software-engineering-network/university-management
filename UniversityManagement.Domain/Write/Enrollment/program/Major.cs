using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Major : Program
    {
        public long CollegeId { get; }

        #region Construction

        public Major(long id, long disciplineId, long collegeId) : base(id, disciplineId, ProgramType.Major)
        {
            if (collegeId == 0)
                throw new ArgumentException();

            CollegeId = collegeId;
        }

        #endregion
    }
}
