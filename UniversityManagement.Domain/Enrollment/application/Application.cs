using System;

namespace UniversityManagement.Domain.Enrollment
{
    public class Application : Entity
    {
        #region Properties

        public Applicant Applicant { get; }
        public College College { get; private set; }
        public Major Major { get; private set; }
        public Minor Minor { get; private set; }

        #endregion

        #region Construction

        public Application(
            Applicant applicant,
            long id = 0
        ) : base(id)
        {
            Applicant = applicant;
        }

        #endregion

        public Application SelectCollege(College college)
        {
            College = college;
            Major = null;
            return this;
        }

        public Application SelectMajor(Major major)
        {
            if (major.CollegeId != College.Id)
                throw new ArgumentException();

            Major = major;
            return this;
        }

        public Application SelectMinor(Minor minor)
        {
            Minor = minor;
            return this;
        }
    }
}
