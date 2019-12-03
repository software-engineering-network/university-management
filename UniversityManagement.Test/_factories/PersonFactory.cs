using UniversityManagement.Domain.Write;

namespace UniversityManagement.Test
{
    public class PersonFactory
    {
        public static Person CreatePerson()
        {
            return new Person(1, "John", "Doe", "111-11-1111");
        }
    }
}
