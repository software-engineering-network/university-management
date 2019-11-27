using System;
using UniversityManagement.Domain.Write;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Infrastructure.Memory.Write.Enrollment;

namespace UniversityManagement.Wpf.Write
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

        public void Commit()
        {
            // ¯\_(ツ)_/¯
        }

        #endregion
    }
}
