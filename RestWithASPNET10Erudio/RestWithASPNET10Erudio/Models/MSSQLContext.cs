using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET10Erudio.Models
{
	public class MSSQLContext : DbContext
	{
		public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) { }

		public DbSet<Person> Persons { get; set; }

	}
}
