using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Program : Entity
    {
        #region Properties

        protected ProgramType ProgramType { get; set; }

        public long CollegeId { get; }
        public long DisciplineId { get; }
        public bool IsProgram => ProgramType.IsProgram;

        #endregion

        #region Construction

        public Program(
            long id,
            long collegeId,
            long disciplineId,
            ProgramType programType
        ) : base(id)
        {
            CollegeId = collegeId == 0
                ? throw new ArgumentException()
                : collegeId;

            DisciplineId = disciplineId == 0
                ? throw new ArgumentException()
                : disciplineId;

            SetProgramType(programType);
        }

        #endregion

        protected virtual void SetProgramType(ProgramType programType)
        {
            ProgramType = programType.IsProgram
                ? programType
                : throw new ArgumentException();
        }
    }
}
