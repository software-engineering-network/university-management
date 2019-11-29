﻿using System.Collections.ObjectModel;
using UniversityManagement.Domain.Read.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public interface IMinorSelectorViewModel
    {
        ObservableCollection<Minor> Minors { get; }
        Minor SelectedMinor { get; set; }
    }
}
