using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Primary : Program
    {
        public Primary(
            long id, 
            long collegeId, 
            long disciplineId, 
            ProgramType programType
        ) : base(id, collegeId, disciplineId, programType)
        {
        }

        protected override void SetProgramType(ProgramType programType)
        {
            if ((programType & ProgramType.Primary) == 0)
                throw new ArgumentException();

            ProgramType = programType;
        }
    }
}
