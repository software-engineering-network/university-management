using System;

namespace UniversityManagement.Services
{
    public abstract class EntityDto : IEquatable<EntityDto>
    {
        #region Properties

        public long Id { get; set; }

        #endregion

        #region Construction

        protected EntityDto()
        {
        }

        protected EntityDto(long id)
        {
            Id = id;
        }

        #endregion

        #region IEquatable<EntityDto> Members

        public bool Equals(EntityDto other)
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
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((EntityDto) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region Operator Overloads

        public static bool operator ==(EntityDto left, EntityDto right)
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

        public static bool operator !=(EntityDto left, EntityDto right)
        {
            return !(left == right);
        }

        #endregion
    }
}
