using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment;
using UniversityManagement.Infrastructure.Memory.Enrollment;

namespace UniversityManagement.Wpf
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICollegeRepository CollegeRepository => new CollegeRepository();
    }
}