namespace UniversityManagement.Wpf.Enrollment
{
    public interface IApplicantViewModel
    {
        #region Properties

        string ApplicantName { get; set; }
        string ApplicantNameValidationMessage { get; }
        string ApplicantSurname { get; set; }
        string ApplicantSurnameValidationMessage { get; }

        #endregion
    }
}
