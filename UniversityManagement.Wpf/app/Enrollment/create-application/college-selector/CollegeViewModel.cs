using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class CollegeViewModel :
        ViewModelBase,
        ISelectorItemViewModel<CollegeDto>
    {
        public long Id => Value.Id;
        public string Text => Value.Name;
        public CollegeDto Value { get; }

        public CollegeViewModel(CollegeDto college)
        {
            Value = college;
        }
    }
}
