using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment.Read;
using UniversityManagement.Domain.Read;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Infrastructure.Memory.Enrollment;

namespace UniversityManagement.Wpf
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Members

        public IApplicationRepository ApplicationRepository => new ApplicationRepository(_context);
        public IApplicantRepository ApplicantRepository => new ApplicantRepository(_context);
        public ICollegeRepository CollegeRepository => new CollegeRepository(_context);
        public IDisciplineRepository DisciplineRepository => new DisciplineRepository(_context);
        public IMajorRepository MajorRepository => new MajorRepository(_context);
        public IMinorRepository MinorRepository => new MinorRepository(_context);

        #endregion
    }
}
