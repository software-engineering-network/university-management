using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Program : Entity
    {
        #region Properties

        public long CollegeId { get; }
        public long DisciplineId { get; }
        public ProgramType ProgramType { get; }

        #endregion

        #region Construction

        public Program(
            long id,
            long collegeId,
            long disciplineId,
            ProgramType programType
        ) : base(id)
        {
            if (collegeId == 0)
                throw new ArgumentException();

            CollegeId = collegeId;

            if (disciplineId == 0)
                throw new ArgumentException();

            DisciplineId = disciplineId;
            
            if ((programType & ProgramType.Primary) == 0)
                throw new ArgumentException();
            
            ProgramType = programType;
        }
        
        #endregion
    }
}
