﻿using UniversityManagement.Domain.Read;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Infrastructure.Memory.Read.Enrollment;

namespace UniversityManagement.Wpf.Read
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
        public IMinorRepository MinorRepository => new MinorRepository(_context);
        public IProgramRepository ProgramRepository => new ProgramRepository(_context);

        #endregion
    }
}