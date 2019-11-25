using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Domain
{
    public interface IUnitOfWork
    {
        ICollegeRepository CollegeRepository { get; }
        IMajorRepository MajorRepository { get; }
    }
}
