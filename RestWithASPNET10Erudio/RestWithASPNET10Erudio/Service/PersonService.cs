using Mapster;
using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Models.DTOs;
using RestWithASPNET10Erudio.Repositories.Interfaces;

namespace RestWithASPNET10Erudio.Service
{
	public class PersonService: IPersonService
	{
		public IRepository<Person> _personRepository { get; }

		public PersonService(IRepository<Person> personRepository)
		{
			_personRepository = personRepository;
		}

		public List<PersonDTO> GetAll() => _personRepository.GetAll().Adapt<List<PersonDTO>>();

		public PersonDTO GetById(Guid id) => _personRepository.GetById(id).Adapt<PersonDTO>();

		public void Create(PersonDTO person)
		{
			_personRepository.Create(person.Adapt<Person>());
		}

		public void Update(PersonDTO person)
		{
			_personRepository.Update(person.Adapt<Person>());
		}

		public void Delete(Guid id) {
			_personRepository.Delete(id);
		}
	}
}
