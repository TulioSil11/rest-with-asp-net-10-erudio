using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Service;

namespace RestWithASPNET10Erudio.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonController : ControllerBase
	{
		public IPersonService _personService { get; }

		public PersonController(IPersonService personService)
		{
			_personService = personService;
		}

		[HttpGet]
		public IEnumerable<Person> GetAll()
		{
			return _personService.GetAll();
		}

		[HttpGet("{id}")]
		public Person GetById(Guid id)
		{
			return _personService.GetById(id);
		}

		[HttpPost]
		public void Create([FromBody] Person person)
		{
			_personService.Create(person);
		}


		[HttpPut]
		public void Update([FromBody] Person person)
		{
			_personService.Update(person);
		}


		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			_personService.Delete(id);
		}
	}
}
