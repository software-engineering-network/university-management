using System;

namespace UniversityManagement.Domain.Write
{
    public class Person : Entity
    {
        #region Properties

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public SocialSecurityNumber SocialSecurityNumber { get; private set; }

        #endregion

        #region Construction

        public Person(
            string name, 
            string surname,
            string socialSecurityNumber
        )
        {
            UpdateName(name);
            UpdateSurname(surname);
            UpdateSocialSecurityNumber(socialSecurityNumber);
        }

        public Person(
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

        public Person UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();

            Name = name;

            return this;
        }

        public Person UpdateSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException();

            Surname = surname;

            return this;
        }

        public Person UpdateSocialSecurityNumber(string socialSecurityNumber)
        {
            SocialSecurityNumber = new SocialSecurityNumber(socialSecurityNumber);

            return this;
        }
    }
}
