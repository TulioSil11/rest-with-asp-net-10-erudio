using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Models.DTOs;

namespace RestWithASPNET10Erudio.Service
{
	public interface IPersonService
	{
		List<PersonDTO> GetAll();

		PersonDTO GetById(Guid id);

		void Create(PersonDTO person);

		void Update(PersonDTO person);

		void Delete(Guid id);
	}
}