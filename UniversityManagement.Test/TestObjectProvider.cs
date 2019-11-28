using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using IApplicationRepository = UniversityManagement.Domain.Read.Enrollment.IApplicationRepository;

namespace UniversityManagement.Test
{
    public class TestObjectProvider
    {
        #region Fields

        private IApplicationProcessor _applicationProcessor;
        private IApplicationRepository _applicationRepository;
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

        public IApplicationProcessor ApplicationProcessor
        {
            get => _applicationProcessor ?? 
                   (_applicationProcessor = ServiceFactory.CreateApplicationProcessor(UnitOfWork));
            set => _applicationProcessor = value;
        }

        #endregion
    }
}
