using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Applicant : Person
    {
        public List<Application> Applications { get; set; }

        #region Construction

        public Applicant(string name, string surname, SocialSecurityNumber socialSecurityNumber) : base(
            name,
            surname,
            socialSecurityNumber
        )
        {
        }

        public Applicant(string name, string surname, string socialSecurityNumber) : base(
            name,
            surname,
            socialSecurityNumber
        )
        {
        }

        public Applicant(long id, string name, string surname, SocialSecurityNumber socialSecurityNumber) : base(
            id,
            name,
            surname,
            socialSecurityNumber
        )
        {
        }

        public Applicant(long id, string name, string surname, string socialSecurityNumber) : base(
            id,
            name,
            surname,
            socialSecurityNumber
        )
        {
        }

        #endregion

        public void Apply(Program program, Minor minor)
        {
            if (Applications.Any(x => x.ProgramId == program.Id))
                throw new ArgumentOutOfRangeException(nameof(Program));

            var application = new Application(Id, program, minor);

            Applications.Add(application);
        }
    }
}
