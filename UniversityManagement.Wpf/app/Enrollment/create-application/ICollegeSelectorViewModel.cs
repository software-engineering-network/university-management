using System.Collections.ObjectModel;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface ICollegeSelectorViewModel
    {
        #region Properties

        ObservableCollection<CollegeDto> Colleges { get; }
        CollegeDto SelectedCollege { get; set; }

        #endregion
    }
}
