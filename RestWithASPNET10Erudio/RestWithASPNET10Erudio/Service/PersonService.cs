using RestWithASPNET10Erudio.Models;
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
