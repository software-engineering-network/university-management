using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Applicant : Entity
    {
        #region Properties

        public string Name { get; private set; }
        public string Surname { get; private set; }

        #endregion

        #region Construction

        public Applicant(string name, string surname)
        {
            UpdateName(name);
            UpdateSurname(surname);
        }

        public Applicant(long id, string name, string surname) : base(id)
        {
            UpdateName(name);
            UpdateSurname(surname);
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
    }
}
