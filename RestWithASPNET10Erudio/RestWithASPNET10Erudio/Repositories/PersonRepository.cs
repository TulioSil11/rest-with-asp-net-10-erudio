using RestWithASPNET10Erudio.Models;

namespace RestWithASPNET10Erudio.Repositories
{
	public class PersonRepository: IPersonRepository
	{
		private MSSQLContext _context;
		public PersonRepository(MSSQLContext context)
		{
			_context = context;
		}

		public List<Person> GetAll() => _context.Persons.ToList();

		public Person GetById(Guid id) => _context.Persons.FirstOrDefault(person => person.Id == id);

		public void Create(Person person)
		{
			_context.Persons.Add(person);
			_context.SaveChanges();
		}

		public void Update(Person person)
		{
			var existingPerson = _context.Persons.Find(person.Id);
			if (existingPerson == null) return;

			_context.Entry(existingPerson).CurrentValues.SetValues(person);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			var existingPerson = _context.Persons.Find(id);
			if (existingPerson == null) return;
			_context.Remove(existingPerson);
			_context.SaveChanges();
		}
	}
}
