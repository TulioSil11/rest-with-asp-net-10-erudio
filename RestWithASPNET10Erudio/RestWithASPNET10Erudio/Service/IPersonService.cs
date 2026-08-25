using RestWithASPNET10Erudio.Models;

namespace RestWithASPNET10Erudio.Service
{
	public interface IPersonService
	{
		List<Person> GetAll();

		Person GetById(Guid id);

		void Create(Person person);

		void Update(Person person);

		void Delete(Guid id);
	}
}