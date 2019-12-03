using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain.Write;
using UniversityManagement.Infrastructure.Memory.Database;
using Person = UniversityManagement.Domain.Write.Person;

namespace UniversityManagement.Infrastructure.Memory.Write.Enrollment
{
    public class PersonRepository : IPersonRepository
    {
        #region Fields

        private readonly Context _context;

        #endregion

        #region Construction

        public PersonRepository(Context context)
        {
            _context = context;
        }

        #endregion

        #region IPersonRepository Members

        public IEnumerable<Person> Fetch()
        {
            throw new NotSupportedException();
        }

        public Person Find(long id)
        {
            var record = _context.People.First(x => x.Id == id);

            return new Person(
                record.Id,
                record.Name,
                record.Surname,
                record.SocialSecurityNumber
            );
        }

        public void Create(Person person)
        {
            var record = new Database.Person(
                person.Id,
                person.Name,
                person.Surname,
                person.SocialSecurityNumber.Value
            );

            _context.People.Insert(record);
        }

        public void Update(Person person)
        {
            var record = _context.People.First(x => x.Id == person.Id);

            Action update = () =>
            {
                record.Name = person.Name;
                record.Surname = person.Surname;
                record.SocialSecurityNumber = person.SocialSecurityNumber.Value;
            };

            _context.People.Update(update);
        }

        public bool Exists(SocialSecurityNumber socialSecurityNumber)
        {
            var person = _context.People.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber.Value);
            return person != null;
        }

        public Person Find(SocialSecurityNumber socialSecurityNumber)
        {
            var record = _context.People.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber.Value);

            if (record == null)
                return null;

            var person = new Person(
                record.Id,
                record.Name,
                record.Surname,
                record.SocialSecurityNumber
            );

            return person;
        }

        #endregion
    }
}
