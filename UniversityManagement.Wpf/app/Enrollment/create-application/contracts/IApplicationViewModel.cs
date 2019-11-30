namespace UniversityManagement.Wpf.Enrollment
{
    public interface IApplicationViewModel
    {
        bool IsValid { get; }

        void SaveApplication();
    }
}
