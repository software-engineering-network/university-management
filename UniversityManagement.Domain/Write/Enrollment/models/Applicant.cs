using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Applicant : Entity
    {
        #region Properties

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public SocialSecurityNumber SocialSecurityNumber { get; private set; }

        #endregion

        #region Construction

        public Applicant(
            string name, 
            string surname,
            string socialSecurityNumber
        )
        {
            UpdateName(name);
            UpdateSurname(surname);
            UpdateSocialSecurityNumber(socialSecurityNumber);
        }

        public Applicant(
            long id, 
            string name, 
            string surname,
            string socialSecurityNumber
        ) : base(id)
        {
            UpdateName(name);
            UpdateSurname(surname);
            UpdateSocialSecurityNumber(socialSecurityNumber);
        }

        #endregion

        public Applicant UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();

            Name = name;

            return this;
        }

        public Applicant UpdateSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException();

            Surname = surname;

            return this;
        }

        public Applicant UpdateSocialSecurityNumber(string socialSecurityNumber)
        {
            SocialSecurityNumber = new SocialSecurityNumber(socialSecurityNumber);

            return this;
        }
    }
}
