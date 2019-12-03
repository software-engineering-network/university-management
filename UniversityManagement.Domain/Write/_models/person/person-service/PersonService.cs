using System;

namespace UniversityManagement.Domain.Write
{
    public class PersonService : IPersonService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        public void Create(Person person)
        {
            if (person.Id != 0)
                throw new ArgumentException();

            if (_unitOfWork.PersonRepository.Exists(person.SocialSecurityNumber))
                throw new ArgumentException();

            _unitOfWork.PersonRepository.Create(person);
        }

        public void Update(Person person)
        {
            var existingPerson = _unitOfWork.PersonRepository.Find(person.Id);
            if (existingPerson == person)
                return;

            // don't overwrite different person's SSN
            var x = _unitOfWork.PersonRepository.Find(person.SocialSecurityNumber);
            if (x.Id != person.Id)
                throw new ArgumentException();
            
            _unitOfWork.PersonRepository.Update(person);
        }
    }
}
