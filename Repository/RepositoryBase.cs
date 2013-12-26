using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public class RepositoryBase<T> : DbRepositoryBase<T> where T : class {
		public RepositoryBase() : base( new WikiContext( "WikiContext" ) ) { }

		public RepositoryBase( WikiContext context ):base(new DataContext("DataContext")) {
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
