using System.Collections.ObjectModel;
using System.Linq;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class CollegeSelectorViewModel : SelectorViewModel<CollegeViewModel>
    {
        private readonly ApplicationDto _application;

        public override CollegeViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value)
                    return;

                _selectedItem = value;
                _application.College = value.Value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public CollegeSelectorViewModel(
            ApplicationDto application,
            ICollegeReadService collegeReadService
        )
        {
            _application = application;

            var collegeViewModels = collegeReadService
                .FetchColleges()
                .Select(x => new CollegeViewModel(x));

            Items = new ObservableCollection<CollegeViewModel>(collegeViewModels);

            SelectedItem = Items.FirstOrDefault(x => x.Value == _application.College);
        }
    }
}
