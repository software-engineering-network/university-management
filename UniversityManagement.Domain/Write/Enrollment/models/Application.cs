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

        private Program Program { get; set; }

        public long ApplicantId { get; private set; }
        public long CollegeId => Program.CollegeId;
        public long MinorId { get; private set; }
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
            SetApplicant(applicant);
            SetProgram(program);
            SetMinor(minor);
        }

        #endregion

        private void SetApplicant(Person applicant)
        {
            if (applicant == null || applicant.Id == 0)
                throw new ArgumentException();

            ApplicantId = applicant.Id;
        }

        private void SetMinor(Minor minor)
        {
            if (minor == null)
                return;

            if (minor.DisciplineId == Program.DisciplineId)
                throw new ArgumentException();

            MinorId = minor.Id;
        }

        private void SetProgram(Program program)
        {
            if (program == null || !program.IsProgram)
                throw new ArgumentException();

            Program = program;
        }
    }
}
