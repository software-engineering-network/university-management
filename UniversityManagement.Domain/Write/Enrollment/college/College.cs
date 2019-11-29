using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class College : Entity
    {
        public string Name { get; }

        public College(
            long id,
            string name
        ) : base(id)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();

            Name = name;
        }
    }
}
