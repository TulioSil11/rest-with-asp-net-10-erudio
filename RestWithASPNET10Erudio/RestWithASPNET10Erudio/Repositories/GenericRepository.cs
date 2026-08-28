using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Models.Base;
using RestWithASPNET10Erudio.Repositories.Interfaces;

namespace RestWithASPNET10Erudio.Repositories
{
	public class GenericRepository<T>: IRepository<T> where T : BaseEntity
	{
		private MSSQLContext _context;
		private DbSet<T> _dataset;

		public GenericRepository(MSSQLContext context)
		{
			_context = context;
			_dataset = _context.Set<T>();
		}

		public List<T> GetAll() => _dataset.ToList();

		public T GetById(Guid id) => _dataset.FirstOrDefault(model => model.Id == id);

		public void Create(T model)
		{
			_dataset.Add(model);
			_context.SaveChanges();
		}

		public void Update(T model)
		{
			var existingPerson = _dataset.Find(model.Id);
			if (existingPerson == null) return;

			_dataset.Entry(existingPerson).CurrentValues.SetValues(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			var existingPerson = _dataset.Find(id);
			if (existingPerson == null) return;
			_dataset.Remove(existingPerson);
			_context.SaveChanges();
		}
	}
}
