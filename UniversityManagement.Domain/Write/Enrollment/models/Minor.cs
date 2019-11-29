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
            if (!programType.IsMinor)
                throw new ArgumentException();

            ProgramType = programType;
        }
    }
}
