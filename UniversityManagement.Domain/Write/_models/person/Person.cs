using System;

namespace UniversityManagement.Domain.Write
{
    public class Person :
        Entity,
        IEquatable<Person>
    {
        #region Fields

        private string _name;
        private SocialSecurityNumber _socialSecurityNumber;
        private string _surname;

        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException()
                : value;
        }

        public SocialSecurityNumber SocialSecurityNumber
        {
            get => _socialSecurityNumber;
            set => _socialSecurityNumber = value ?? throw new ArgumentNullException(nameof(SocialSecurityNumber));
        }

        public string Surname
        {
            get => _surname;
            set => _surname = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException()
                : value;
        }

        #endregion

        #region Construction

        public Person(
            string name,
            string surname,
            SocialSecurityNumber socialSecurityNumber
        )
        {
            Name = name;
            Surname = surname;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public Person(
            string name,
            string surname,
            string socialSecurityNumber
        ) : this(
            name,
            surname,
            new SocialSecurityNumber(socialSecurityNumber)
        )
        {
        }

        public Person(
            long id,
            string name,
            string surname,
            SocialSecurityNumber socialSecurityNumber
        ) : base(id)
        {
            Name = name;
            Surname = surname;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public Person(
            long id,
            string name,
            string surname,
            string socialSecurityNumber
        ) : this(
            id,
            name,
            surname,
            new SocialSecurityNumber(socialSecurityNumber)
        )
        {
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

        #region IEquatable<Person>

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
    }
}
