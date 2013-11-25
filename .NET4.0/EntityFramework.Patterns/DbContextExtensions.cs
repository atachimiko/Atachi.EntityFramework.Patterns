using System.Data.Entity;
using System.Data.Entity.Infrastructure;

#if EF5
using System.Data.Objects;
#else
using System.Data.Entity.Core.Objects;
#endif

namespace EntityFramework.Patterns
{
    public static class DbContextExtensions
    {
        public static ObjectContext GetObjectContext(this DbContext dbContext)
        {
            return ((IObjectContextAdapter) dbContext).ObjectContext;
        }
    }
}