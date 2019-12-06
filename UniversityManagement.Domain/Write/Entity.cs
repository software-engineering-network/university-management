using System;

namespace UniversityManagement.Domain.Write
{
    public abstract class Entity : IEquatable<Entity>
    {
        #region Properties

        public bool Exists => Id != 0;
        public long Id { get; }

        #endregion

        #region Construction

        protected Entity()
        {
        }

        protected Entity(long id)
        {
            Id = id;
        }

        #endregion

        #region IEquatable<Entity> Members

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) 
                return false;

            if (ReferenceEquals(this, other)) 
                return true;

            return Id == other.Id;
        }

        #endregion

        #region object Overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region Operator Overloads

        public static bool operator ==(Entity left, Entity right)
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

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion
    }
}
