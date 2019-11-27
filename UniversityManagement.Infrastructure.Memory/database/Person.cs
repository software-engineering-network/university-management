namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class Person : Entity
    {
        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }

        #endregion

        #region Construction

        public Person(
            long id,
            string name,
            string surname
        )
            : base(id)
        {
            Name = name;
            Surname = surname;
        }

        #endregion
    }
}
