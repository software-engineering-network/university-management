using UniversityManagement.Services;

namespace UniversityManagement.Wpf
{
    public interface ISelectorItemViewModel<T> where T : EntityDto
    {
        long Id { get; }
        string Text { get; }
        T Value { get; }
    }
}
