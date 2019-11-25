using System.Collections.Generic;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Infrastructure.Memory.Enrollment
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly List<College> _colleges;

        public CollegeRepository()
        {
            _colleges = PopulateColleges();
        }

        public IEnumerable<College> Fetch()
        {
            return _colleges;
        }

        private static List<College> PopulateColleges()
        {
            return new List<College>
            {
                new College("Arts & Sciences", 1),
                new College("Business Administration", 2),
                new College("Engineering", 3),
                new College("Law", 4),
                new College("Pharmacy", 5),
                new College("Interdisciplinary Studies", 6),
            };
        }
    }
}
