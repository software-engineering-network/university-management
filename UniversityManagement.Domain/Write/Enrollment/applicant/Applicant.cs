using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Applicant : Entity
    {
        private string _name;
        private string _surname;

        #region Properties

        public string Name
        {
            get => _name;
            private set
            {
                if (_name == value)
                    return;

                _name = value;
                HasChanged = true;
            }
        }

        public string Surname
        {
            get => _surname;
            private set
            {
                if (_surname == value)
                    return;

                _surname = value;
                HasChanged = true;
            }
        }

        public bool HasChanged { get; private set; }

        #endregion

        public Applicant(string name, string surname)
        {
            UpdateName(name);
            UpdateSurname(surname);
        }

        public Applicant(
            long id,
            string name,
            string surname
        ) : base(id)
        {
            UpdateName(name);
            UpdateSurname(surname);
        }

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
