namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Applicant : Entity
    {
        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }

        #endregion

        public Applicant()
        {
        }

        public Applicant(
            string name,
            string surname,
            long id = 0
        ) : base(id)
        {
            Name = name;
            Surname = surname;
        }
    }
}
