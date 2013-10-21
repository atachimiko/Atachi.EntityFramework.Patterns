using System.Data;
using System.Data.Entity;

namespace EntityFramework.Patterns
{
	public class DbContextAdapter : IObjectSetFactory, IObjectContext
	{
		private readonly DbContext _context;
		//private readonly ObjectContext _context;

		public DbContextAdapter(DbContext context)
		{
			_context = context;
			//_context = context.GetObjectContext();
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
		//public IObjectSet<T> CreateObjectSet<T>() where T : class
		{
			return _context.Set<T>();
			//return _context.CreateObjectSet<T>();
		}

		public void ChangeObjectState(object entity, EntityState state)
		{
			//var d = _context.GetObjectContext();
			//_context.ObjectStateManager.ChangeObjectState(entity, state);

			_context.Entry(entity).State = state;
		}

		#endregion
	}
}