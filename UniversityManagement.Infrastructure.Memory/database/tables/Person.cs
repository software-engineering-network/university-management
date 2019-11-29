using System;

namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class Person : Entity, IEquatable<Person>
    {
        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }

        #endregion

        #region Construction

        public Person()
        {
        }

        public Person(
            long id,
            string name,
            string surname
        )
            : base(id)
        {
            Name = name;
            Surname = surname;
        }

        #endregion

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return
                Id == other.Id &&
                Name == other.Name &&
                Surname == other.Surname;
        }

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
            return Id.GetHashCode();
        }

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
    }
}
