using System.Collections.ObjectModel;
using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
using Application = UniversityManagement.Domain.Read.Enrollment.Application;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using ICollegeRepository = UniversityManagement.Domain.Read.Enrollment.ICollegeRepository;
using IMinorRepository = UniversityManagement.Domain.Read.Enrollment.IMinorRepository;
using IProgramRepository = UniversityManagement.Domain.Read.Enrollment.IProgramRepository;
using Minor = UniversityManagement.Domain.Read.Enrollment.Minor;
using Program = UniversityManagement.Domain.Read.Enrollment.Program;

namespace UniversityManagement.Services.Enrollment
{
    public class CreateApplicationService : ICreateApplicationService
    {
        #region Fields

        private readonly IApplicationProcessor _applicationProcessor;
        private readonly ICollegeRepository _collegeRepository;
        private readonly IMinorRepository _minorRepository;
        private readonly IProgramRepository _programRepository;

        #endregion

        #region Construction

        public CreateApplicationService(
            IApplicationProcessor applicationProcessor,
            ICollegeRepository collegeRepository,
            IMinorRepository minorRepository,
            IProgramRepository programRepository
        )
        {
            _applicationProcessor = applicationProcessor;
            _collegeRepository = collegeRepository;
            _minorRepository = minorRepository;
            _programRepository = programRepository;
        }

        #endregion

        #region ICreateApplicationService Members

        public ObservableCollection<College> FetchColleges()
        {
            var colleges = _collegeRepository.Fetch();
            return new ObservableCollection<College>(colleges);
        }

        public ObservableCollection<Minor> FetchMinors()
        {
            var minors = _minorRepository.Fetch();
            return new ObservableCollection<Minor>(minors);
        }

        public ObservableCollection<Minor> FetchMinors(long collegeId)
        {
            var minors = _minorRepository.Fetch(collegeId);
            return new ObservableCollection<Minor>(minors);
        }

        public ObservableCollection<Program> FetchPrograms()
        {
            var programs = _programRepository.Fetch();
            return new ObservableCollection<Program>(programs);
        }

        public ObservableCollection<Program> FetchPrograms(long collegeId)
        {
            var programs = _programRepository.Fetch(collegeId);
            return new ObservableCollection<Program>(programs);
        }

        public void CreateApplication(Application application)
        {
            var command = new CreateApplication(application);
            _applicationProcessor.CreateApplication(command);
        }

        public IValidationResult Validate(Application application)
        {
            var command = new CreateApplication(application);
            return _applicationProcessor.Validate(command);
        }

        #endregion
    }
}
