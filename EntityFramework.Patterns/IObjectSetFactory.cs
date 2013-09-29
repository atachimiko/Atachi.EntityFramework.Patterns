using System;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;

namespace EntityFramework.Patterns
{
    public interface IObjectSetFactory : IDisposable
    {
        IDbSet<T> CreateObjectSet<T>() where T : class;
		//IObjectSet<T> CreateObjectSet<T>() where T : class;
        void ChangeObjectState(object entity, EntityState state);
    }
}