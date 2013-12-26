using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.EF {
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
