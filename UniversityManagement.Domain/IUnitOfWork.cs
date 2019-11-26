using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Domain
{
    public interface IUnitOfWork
    {
        ICollegeRepository CollegeRepository { get; }
        IDisciplineRepository DisciplineRepository { get; }
        IMajorRepository MajorRepository { get; }
        IMinorRepository MinorRepository { get; }
    }
}
