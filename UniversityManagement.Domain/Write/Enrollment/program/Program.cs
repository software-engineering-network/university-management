using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public abstract class Program : Entity
    {
        #region Properties

        public long CollegeId { get; private set; }
        public long DisciplineId { get; private set; }
        public ProgramType ProgramType { get; protected set; }

        #endregion

        #region Construction

        protected Program(
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

        protected abstract void SetProgramType(ProgramType programType);
    }
}
