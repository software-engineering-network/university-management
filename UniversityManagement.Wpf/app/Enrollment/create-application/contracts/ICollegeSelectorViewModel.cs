using System.Collections.ObjectModel;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

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
