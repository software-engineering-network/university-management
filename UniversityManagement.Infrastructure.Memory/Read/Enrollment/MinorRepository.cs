﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
using College = UniversityManagement.Domain.Read.Enrollment.College;
using Discipline = UniversityManagement.Domain.Read.Enrollment.Discipline;
using ProgramType = UniversityManagement.Domain.Read.Enrollment.ProgramType;

namespace UniversityManagement.Infrastructure.Memory.Read.Enrollment
{
    public class MinorRepository : IMinorRepository
    {
        private const long MinorProgramTypeId = 4;

        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public MinorRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IMinorRepository Members

        public IEnumerable<Minor> Fetch()
        {
            var minors = _context.Programs
                .Where(x => x.ProgramTypeId == MinorProgramTypeId)
                .Join(
                    _context.Disciplines,
                    program => program.DisciplineId,
                    discipline => discipline.Id,
                    (Program, Discipline) => new {Program, Discipline}
                )
                .Join(
                    _context.Colleges,
                    x => x.Discipline.CollegeId,
                    college => college.Id,
                    (x, College) => new { x.Program, x.Discipline, College }
                )
                .Join(
                    _context.ProgramTypes,
                    x => x.Program.ProgramTypeId,
                    programType => programType.Id,
                    (x, ProgramType) => new { x.Program, x.College, x.Discipline, ProgramType }
                )
                .Select(
                    x =>
                    {
                        var minor = Mapper.Map<Database.Program, Minor>(x.Program);
                        minor.College = Mapper.Map<Database.College, College>(x.College);
                        minor.Discipline = Mapper.Map<Database.Discipline, Discipline>(x.Discipline);
                        minor.ProgramType = Mapper.Map<Database.ProgramType, ProgramType>(x.ProgramType);
                        return minor;
                    }
                );

            return minors;
        }

        public Minor Find(long id)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
