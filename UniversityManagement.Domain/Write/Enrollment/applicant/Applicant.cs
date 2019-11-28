using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Applicant : Entity
    {
        #region Properties

        public string Name { get; private set; }
        public string Surname { get; private set; }

        #endregion

        public Applicant(
            string name,
            string surname,
            long id = 0
        ) : base(id)
        {
            UpdateName(name);
            Surname = surname;
        }

        public Applicant UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();

            Name = name;

            return this;
        }
    }
}
