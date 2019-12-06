using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Minor : Program
    {
        public Minor(
            long id, 
            long collegeId, 
            long disciplineId, 
            ProgramType programType
        ) : base(id, collegeId, disciplineId, programType)
        {
        }

        protected override void SetProgramType(ProgramType programType)
        {
            ProgramType = programType.IsMinor
                ? programType
                : throw new ArgumentException();
        }
    }
}
