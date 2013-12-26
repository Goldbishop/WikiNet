using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace Wiki.Repository {
	public abstract class RepositoryBase {
		public RepositoryBase( WikiContext context ) {
			this.Context = context;
		}

		public WikiContext Context { get; private set; }
	}

	public interface IRepositoryBase<TEntity> where TEntity : class {
		ObjectSet<TEntity> Entity { get; }

		void Save( TEntity entity );
		void Delete( TEntity entity );

		IEnumerable<TEntity> AllInformation();
		IEnumerable<TEntity> FindAll();
	}
}
