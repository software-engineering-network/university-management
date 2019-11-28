using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Domain.Write;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Write;

namespace UniversityManagement.Test
{
    public class TestObjectProvider
    {
        #region Fields

        private IApplicationProcessor _applicationProcessor;
        private IApplicationRepository _applicationRepository;
        private IApplicationWriteService _applicationWriteService;
        private Context _context;
        private IUnitOfWork _unitOfWork;

        #endregion

        #region Properties

        public Context Context
        {
            get => _context ?? (_context = ContextFactory.Create());
            set => _context = value;
        }

        public IUnitOfWork UnitOfWork
        {
            get => _unitOfWork ?? (_unitOfWork = UnitOfWorkFactory.Create(Context));
            set => _unitOfWork = value;
        }

        public IApplicationRepository ApplicationRepository
        {
            get => _applicationRepository ??
                   (_applicationRepository = RepositoryFactory.CreateApplicationRepository(Context));
            set => _applicationRepository = value;
        }

        public IApplicationWriteService ApplicationWriteService
        {
            get => _applicationWriteService ??
                   (_applicationWriteService = ServiceFactory.CreateApplicationWriteService(UnitOfWork));
            set => _applicationWriteService = value;
        }

        public IApplicationProcessor ApplicationProcessor
        {
            get => _applicationProcessor ??
                   (_applicationProcessor = ServiceFactory.CreateApplicationProcessor(ApplicationWriteService));
            set => _applicationProcessor = value;
        }

        #endregion
    }
}
