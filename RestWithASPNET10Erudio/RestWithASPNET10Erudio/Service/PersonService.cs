using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Service
{
	public class PersonService: IPersonService
	{
		public IPersonRepository _personRepository { get; }

		public PersonService(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public List<Person> GetAll() => _personRepository.GetAll();

		public Person GetById(Guid id) => _personRepository.GetById(id);

		public void Create(Person person)
		{
			_personRepository.Create(person);
		}

		public void Update(Person person)
		{
			_personRepository.Update(person);
		}

		public void Delete(Guid id) {
			_personRepository.Delete(id);
		}
	}
}
