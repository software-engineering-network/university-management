﻿namespace UniversityManagement.Domain.Enrollment
{
    public class Application : Entity
    {
        public Applicant Applicant { get; }
        public College College { get; private set; }
        public Major Major { get; private set; }

        public Application(Applicant applicant)
        {
            Applicant = applicant;
        }

        public Application SelectCollege(College college)
        {
            College = college;
            Major = null;
            return this;
        }

        public Application SelectMajor(Major major)
        {
            Major = major;
            return this;
        }
    }
}
