using System.Linq;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class ProgramType : Entity
    {
        private const long ConcentrationId = 1;
        private const long MinorId = 4;
        private static readonly long[] ProgramIds = {2, 3, 5, 6};

        #region Properties

        public bool IsConcentration => Id == ConcentrationId;
        public bool IsMinor => Id == MinorId;
        public bool IsProgram => ProgramIds.Contains(Id);
        public string Name { get; }

        #endregion

        #region Construction

        public ProgramType(
            long id,
            string name
        ) : base(id)
        {
            Name = name;
        }

        #endregion
    }
}
