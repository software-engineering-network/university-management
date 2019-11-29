using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Program : Entity
    {
        #region Properties

        public long CollegeId { get; private set; }
        public long DisciplineId { get; private set; }
        public ProgramType ProgramType { get; protected set; }

        #endregion

        #region Construction

        public Program(
            long id,
            long collegeId,
            long disciplineId,
            ProgramType programType
        ) : base(id)
        {
            SetCollegeId(collegeId);
            SetDisciplineId(disciplineId);
            SetProgramType(programType);
        }

        #endregion

        private void SetCollegeId(long collegeId)
        {
            if (collegeId == 0)
                throw new ArgumentException();

            CollegeId = collegeId;
        }

        private void SetDisciplineId(long disciplineId)
        {
            if (disciplineId == 0)
                throw new ArgumentException();

            DisciplineId = disciplineId;
        }

        protected virtual void SetProgramType(ProgramType programType)
        {
            if ((programType & ProgramType.Primary) == 0)
                throw new ArgumentException();

            ProgramType = programType;
        }
    }
}
