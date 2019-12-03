using System;
using System.Collections.Generic;

namespace UniversityManagement.Domain.Write
{
    public class SafetyPersonRepository : IPersonRepository
    {
        #region Fields

        private readonly IPersonRepository _personRepository;

        #endregion

        #region Construction

        public SafetyPersonRepository(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion

        #region IPersonRepository Members

        public IEnumerable<Person> Fetch()
        {
            return _personRepository.Fetch();
        }

        public Person Find(long id)
        {
            return _personRepository.Find(id);
        }

        public void Create(Person person)
        {
            if (person.Id != 0)
                throw new ArgumentException();

            if (_personRepository.Exists(person.SocialSecurityNumber))
                throw new ArgumentException();

            _personRepository.Create(person);
        }

        public void Update(Person person)
        {
            var existingPerson = _personRepository.Find(person.Id);
            if (existingPerson == person)
                return;

            // don't overwrite different person's SSN
            var differentPerson = _personRepository.Find(person.SocialSecurityNumber);
            if (differentPerson != null && differentPerson.Id != person.Id)
                throw new ArgumentException();

            _personRepository.Update(person);
        }

        public bool Exists(SocialSecurityNumber socialSecurityNumber)
        {
            return _personRepository.Exists(socialSecurityNumber);
        }

        public Person Find(SocialSecurityNumber socialSecurityNumber)
        {
            return _personRepository.Find(socialSecurityNumber);
        }

        #endregion
    }
}
