namespace UniversityManagement.Domain.Enrollment
{
    public class Applicant : Entity
    {
        #region Properties

        public string Name { get; }
        public string Surname { get; }

        #endregion

        #region Construction

        public Applicant(
            string name,
            string surname,
            long id = 0
        ) : base(id)
        {
            Name = name;
            Surname = surname;
        }

        #endregion
    }
}
