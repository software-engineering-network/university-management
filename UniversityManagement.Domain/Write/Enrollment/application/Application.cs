using System;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Domain.Write.Enrollment
{
    /// <summary>
    /// Must have exactly one:  graduate program, major, pathway, preprofessional program
    /// May have one minor, cannot be same discipline as major
    /// May have one concentration in same college as major
    /// </summary>
    public class Application : Entity
    {
        #region Properties

        public long ApplicantId { get; private set; }
        public long CollegeId { get; private set; }
        public long MinorId { get; private set; }
        public long ProgramId { get; private set; }

        #endregion

        public Application(Applicant applicant, Program program, Minor minor)
        {
            SetApplicant(applicant);
            SetProgram(program);

            if (minor != null)
                SetMinor(minor);
        }

        private void SetApplicant(Applicant applicant)
        {
            if (applicant == null || applicant.Id == 0)
                throw new ArgumentException();

            ApplicantId = applicant.Id;
        }

        private void SetProgram(Program program)
        {
            if (program == null)
                throw new ArgumentException();

            ProgramId = program.Id;
            CollegeId = program.CollegeId;
        }

        private void SetMinor(Minor minor)
        {
            if (minor.Id == ProgramId)
                throw new ArgumentException();

            MinorId = minor.Id;
        }
    }
}
