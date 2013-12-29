using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public class RepositoryBase<T> : DbRepositoryBase<T> where T : class {
		public RepositoryBase() : base( new WikiContext( "WikiEntities" ) ) { }
	}
}
