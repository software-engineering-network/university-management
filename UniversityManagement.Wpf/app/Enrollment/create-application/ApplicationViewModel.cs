﻿using System.Collections.ObjectModel;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    public class ApplicationViewModel :
        ViewModelBase,
        IApplicantViewModel,
        ICollegeSelectorViewModel,
        IMajorSelectorViewModel
    {
        #region Fields

        private readonly ApplicationDto _application;
        private readonly ICollegeReadService _collegeReadService;
        private readonly IProgramReadService _programReadService;
        private ObservableCollection<CollegeDto> _colleges;
        private ObservableCollection<MajorDto> _majors;

        #endregion

        #region Construction

        public ApplicationViewModel(
            ICollegeReadService collegeReadService,
            IProgramReadService programReadService
        )
        {
            _application = new ApplicationDto();
            _collegeReadService = collegeReadService;
            _programReadService = programReadService;

            PopulateColleges();
            PopulateMajors();
        }

        #endregion

        #region IApplicantViewModel Members

        public string ApplicantName
        {
            get => _application.Applicant.Name;
            set
            {
                if (_application.Applicant.Name == value)
                    return;

                _application.Applicant.Name = value;
                OnPropertyChanged(nameof(ApplicantName));
            }
        }

        public string ApplicantSurname
        {
            get => _application.Applicant.Surname;
            set
            {
                if (_application.Applicant.Surname == value)
                    return;

                _application.Applicant.Surname = value;
                OnPropertyChanged(nameof(ApplicantSurname));
            }
        }

        #endregion

        #region ICollegeSelectorViewModel Members

        public ObservableCollection<CollegeDto> Colleges
        {
            get => _colleges;
            private set
            {
                if (_colleges == value)
                    return;

                _colleges = value;
                OnPropertyChanged(nameof(Colleges));
            }
        }

        public CollegeDto SelectedCollege
        {
            get => _application.College;
            set
            {
                if (_application.College == value)
                    return;

                _application.College = value;
                
                OnPropertyChanged(nameof(SelectedCollege));
                PopulateMajors();
            }
        }

        #endregion

        #region IMajorSelectorViewModel Members

        public ObservableCollection<MajorDto> Majors
        {
            get => _majors;
            private set
            {
                if (_majors == value)
                    return;

                _majors = value;
                OnPropertyChanged(nameof(Majors));
            }
        }

        public MajorDto SelectedMajor
        {
            get => _application.Major;
            set
            {
                if (_application.Major == value)
                    return;

                _application.Major = value;

                OnPropertyChanged(nameof(SelectedCollege));
            }
        }

        #endregion

        private void PopulateColleges()
        {
            var colleges = _collegeReadService.FetchColleges();
            Colleges = new ObservableCollection<CollegeDto>(colleges);
        }

        private void PopulateMajors()
        {
            var majors = _application.College == null || _application.College.Id == 0
                ? _programReadService.FetchMajors()
                : _programReadService.FetchMajors(_application.College.Id);

            Majors = new ObservableCollection<MajorDto>(majors);
        }
    }
}
