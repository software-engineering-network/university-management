using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment;
using UniversityManagement.Infrastructure.Memory;
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

        public ICollegeRepository CollegeRepository => new CollegeRepository(_context);
        public IMajorRepository MajorRepository => new MajorRepository(_context);

        #endregion
    }
}
