﻿namespace UniversityManagement.Domain.Enrollment
{
    public class Major : Program
    {
        #region Construction

        public Major(
            long collegeId,
            long disciplineId,
            long id = 0
        ) : base(
            collegeId,
            disciplineId, 
            ProgramType.Major,
            id
        )
        {
        }

        #endregion
    }
}
