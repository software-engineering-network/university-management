namespace UniversityManagement.Domain.Enrollment
{
    public class Applicant : Entity
    {
        public string Name { get; }
        public string Surname { get; }

        public Applicant(
            string name,
            string surname
        )
        {
            Name = name;
            Surname = surname;
        }
    }
}
