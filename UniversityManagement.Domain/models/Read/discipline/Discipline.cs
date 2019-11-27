using UniversityManagement.Domain.Enrollment.Read;

namespace UniversityManagement.Domain.Read
{
    public class Discipline : Entity
    {
        public College College { get; set; }
        public string Name { get; set; }
    }
}
