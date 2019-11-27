using System;
using System.Collections.Generic;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using Program = UniversityManagement.Domain.Write.Enrollment.Program;
using ProgramType = UniversityManagement.Domain.ProgramType;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
{
    public class ApplicantRepository : IApplicantRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public ApplicantRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IApplicantRepository Members

        public Applicant Find(long id)
        {
            var record = _context.People.Find(x => x.Id == id);

            return new Applicant(
                record.Name,
                record.Surname,
                record.Id
            );
        }

        #endregion
    }

    public class ProgramRepository : IProgramRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public ProgramRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IProgramRepository Members

        public Program Find(long id)
        {
            var record = _context.Programs.Find(x => x.Id == id);

            return new Program(
                record.Id,
                record.DisciplineId,
                ProgramTypeExtensions.ToEnum(record.ProgramTypeId)
            );
        }

        #endregion
    }

    public static class ProgramTypeExtensions
    {
        private static readonly IDictionary<long, ProgramType> ProgramTypes = new Dictionary<long, ProgramType>
        {
            {1, ProgramType.Concentration},
            {2, ProgramType.GraduateProgram},
            {3, ProgramType.Major},
            {4, ProgramType.Minor},
            {5, ProgramType.Pathway},
            {6, ProgramType.PreprofessionalProgram}
        };

        public static ProgramType ToEnum(this Database.ProgramType record)
        {
            return ToEnum(record.Id);
        }

        public static ProgramType ToEnum(long programTypeId)
        {
            return ProgramTypes[programTypeId];
        }
    }

    public class MajorRepository : IMajorRepository
    {
        #region IMajorRepository Members

        public Major Find(long id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
