using System;

namespace UniversityManagement.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        public long Id { get; }

        protected Entity()
        {
        }

        protected Entity(long id)
        {
            Id = id;
        }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

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
    }
}
