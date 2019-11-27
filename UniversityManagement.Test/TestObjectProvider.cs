using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Domain.Write;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Write;

namespace UniversityManagement.Test
{
    public class TestObjectProvider
    {
        private static Context _context;
        private static IUnitOfWork _unitOfWork;
        private static IApplicationProcessor _applicationProcessor;
        private static IApplicationRepository _applicationRepository;
        private static IApplicationWriteService _applicationWriteService;

        #region Properties

        public static Context Context
        {
            get => _context ?? (_context = ContextFactory.Create());
            set => _context = value;
        }

        public static IUnitOfWork UnitOfWork
        {
            get => _unitOfWork ?? (_unitOfWork = UnitOfWorkFactory.Create(Context));
            set => _unitOfWork = value;
        }

        public static IApplicationRepository ApplicationRepository
        {
            get => _applicationRepository ??
                   (_applicationRepository = RepositoryFactory.CreateApplicationRepository(Context));
            set => _applicationRepository = value;
        }

        public static IApplicationWriteService ApplicationWriteService
        {
            get => _applicationWriteService ??
                   (_applicationWriteService = ServiceFactory.CreateApplicationWriteService(UnitOfWork));
            set => _applicationWriteService = value;
        }

        public static IApplicationProcessor ApplicationProcessor
        {
            get => _applicationProcessor ??
                   (_applicationProcessor = ServiceFactory.CreateApplicationProcessor(ApplicationWriteService));
            set => _applicationProcessor = value;
        }

        #endregion
    }
}
