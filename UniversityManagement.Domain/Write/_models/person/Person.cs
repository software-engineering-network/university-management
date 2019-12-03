using System;

namespace UniversityManagement.Domain.Write
{
    public class Person :
        Entity,
        IEquatable<Person>
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

        #region IEquatable<Person> Members

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return base.Equals(other) &&
                   Name == other.Name &&
                   Surname == other.Surname &&
                   Equals(
                       SocialSecurityNumber,
                       other.SocialSecurityNumber
                   );
        }

        #endregion

        #region Entity Overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SocialSecurityNumber != null ? SocialSecurityNumber.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        #region Operator Overloads

        public static bool operator ==(Person left, Person right)
        {
            switch (left)
            {
                case null when right is null:
                    return true;
                case null:
                    return false;
                default:
                    return left.Equals(right);
            }
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
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
