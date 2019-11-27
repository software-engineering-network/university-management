using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class College : Entity
    {
        private readonly string _name;
        public string Name { get; set; }

        public College(
            long id,
            string name
        ) : base(id)
        {
            _name = name;
        }
    }
}
