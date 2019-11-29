﻿using System;

namespace UniversityManagement.Domain.Write.Enrollment
{
    public class Program : Entity
    {
        #region Properties

        public long DisciplineId { get; }
        public ProgramType ProgramType { get; }

        #endregion

        #region Construction

        public Program(
            long id,
            long disciplineId,
            ProgramType programType
        ) : base(id)
        {
            if (disciplineId == 0)
                throw new ArgumentException();

            DisciplineId = disciplineId;
            ProgramType = programType;
        }

        #endregion
    }
}
