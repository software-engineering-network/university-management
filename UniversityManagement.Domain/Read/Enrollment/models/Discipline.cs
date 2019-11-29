using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Domain.Read
{
    public class Discipline : Entity
    {
        public College College { get; set; }
        public string Name { get; set; }
    }
}
