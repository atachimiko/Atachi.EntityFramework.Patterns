using System.Data;
using System.Data.Entity;
using System.Data.Objects;

namespace EntityFramework.Patterns
{
	public class DbContextAdapter : IObjectSetFactory, IObjectContext
	{
		private readonly DbContext _context;

		public DbContextAdapter(DbContext context)
		{
			_context = context;
		}

		#region IObjectContext Members

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		#endregion

		#region IObjectSetFactory Members

		public void Dispose()
		{
			_context.Dispose();
		}

		public IDbSet<T> CreateObjectSet<T>() where T : class
		{
			return _context.Set<T>();
		}

		public void ChangeObjectState(object entity, EntityState state)
		{
			var d = _context.GetObjectContext();
			d.ObjectStateManager.ChangeObjectState(entity, state);
		}

		#endregion
	}
}