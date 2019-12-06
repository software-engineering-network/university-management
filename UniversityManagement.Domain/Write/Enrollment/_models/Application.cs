using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    /// <summary>
    /// Must have exactly one:  graduate program, major, pathway, preprofessional program
    /// May have one minor, cannot be same discipline as major
    /// May have one concentration in same college as major (good enough)
    /// </summary>
    public class Application : Entity
    {
        #region Properties

        private Program Program { get; }

        public long ApplicantId { get; }
        public long CollegeId => Program.CollegeId;
        public long MinorId { get; }
        public long ProgramId => Program.Id;

        #endregion

        #region Construction

        public Application(
            Person applicant,
            Program program,
            Minor minor,
            long id = 0
        ) : base(id)
        {
            ApplicantId = applicant == null || applicant.Id == 0
                ? throw new ArgumentException()
                : applicant.Id;

            Program = program == null || !program.IsProgram
                ? throw new ArgumentException()
                : program;

            if (minor != null)
                MinorId = minor.DisciplineId == Program.DisciplineId
                    ? throw new ArgumentException()
                    : minor.Id;
        }

        #endregion
    }
}
