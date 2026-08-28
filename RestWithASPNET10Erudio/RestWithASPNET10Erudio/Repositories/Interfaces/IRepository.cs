using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Models.Base;

namespace RestWithASPNET10Erudio.Repositories.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		List<T> GetAll();

		T GetById(Guid id);

		void Create(T person);

		void Update(T person);

		void Delete(Guid id);
	}
}
