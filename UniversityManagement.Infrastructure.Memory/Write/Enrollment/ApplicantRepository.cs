﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain.Write.Enrollment;
using UniversityManagement.Infrastructure.Memory.Database;
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
                record.Id,
                record.Name,
                record.Surname
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
}
