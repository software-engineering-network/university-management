namespace UniversityManagement.Domain.Read.Enrollment
{
    public class Applicant : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SocialSecurityNumber { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{Surname}, {Name}; SSN - {SocialSecurityNumber}";
        }

        #endregion
    }
}
