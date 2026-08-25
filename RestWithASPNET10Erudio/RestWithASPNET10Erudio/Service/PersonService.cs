using RestWithASPNET10Erudio.Models;

namespace RestWithASPNET10Erudio.Service
{
	public class PersonService: IPersonService
	{
		private List<Person> people;

		public PersonService()
		{
			this.people = new List<Person>();
		}

		public List<Person> GetAll() => people;

		public Person GetById(Guid id) => people.FirstOrDefault(person => person.Id == id);

		public void Create(Person person) => people.Add(person);

		public void Update(Person person)
		{
			var index = people.FindIndex(x => x.Id == person.Id);
			if (index >= 0)
				people[index] = person;
		}

		public void Delete(Guid id) {
			var person = GetById(id);
			if (person != null)
				people.Remove(person);
		}
	}
}
