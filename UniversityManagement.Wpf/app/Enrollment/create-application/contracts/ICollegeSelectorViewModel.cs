using System.Collections.ObjectModel;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface ICollegeSelectorViewModel
    {
        #region Properties

        ObservableCollection<College> Colleges { get; }
        College SelectedCollege { get; set; }

        #endregion
    }
}
