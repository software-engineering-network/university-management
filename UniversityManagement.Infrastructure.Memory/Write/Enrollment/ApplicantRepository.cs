using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
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
            var record = _context.People.First(x => x.Id == id);

            return new Applicant(
                record.Name,
                record.Surname,
                record.Id
            );
        }

        public void Create(Applicant applicant)
        {
            var person = Mapper.Map<Applicant, Person>(applicant);
            _context.People.Add(person);
        }

        public void Update(Applicant applicant)
        {
            var candidatePerson = Mapper.Map<Applicant, Person>(applicant);
            var person = _context.People.First(x => x.Id == applicant.Id);

            if (person == candidatePerson)
                return;

            Action update = () =>
            {
                person.Name = candidatePerson.Name;
                person.Surname = candidatePerson.Surname;
            };

            _context.People.Update(update);
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
            var record = _context.Programs.First(x => x.Id == id);

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
        #region Fields

        private readonly IProgramRepository _programRepository;

        #endregion

        #region Construction

        public MajorRepository(Context context)
        {
            _programRepository = new ProgramRepository(context);
        }

        #endregion

        #region IMajorRepository Members

        public Major Find(long id)
        {
            var program = _programRepository.Find(id);
            return new Major(program.Id, program.DisciplineId);
        }

        #endregion
    }
}
