using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.EF {
	public class NamespaceRepository:RepositoryBase, INamespaceRepository {
		public NamespaceRepository( WikiContext context ) : base( context ) { }

		#region INamespaceRepository Members

		public IEnumerable<Namespace> AllInformation() {
			return Entity
				.Include( "Articles" );
		}

		public Namespace Find( string Name ) {
			return AllInformation()
				.Where( ns => ns.Name == Name ).SingleOrDefault();
		}

		public bool Exists( string Name ) {
			return FindAll()
				.Any( ns => ns.Name == Name );
		}

		#endregion

		#region IRepositoryBase<Namespace> Members

		public ObjectSet<Namespace> Entity {
			get { return Context.Namespaces; }
		}

		public void Save( Namespace entity ) {
			if( !Entity.Contains( entity ) )
				Entity.AddObject( entity );
		}

		public void Delete( Namespace entity ) {
			if( Entity.Contains( entity ) )
				Entity.DeleteObject( entity );
		}

		public IEnumerable<Namespace> FindAll() {
			return Entity;
		}

		#endregion
	}

	public interface INamespaceRepository:IRepositoryBase<Namespace> {

		Namespace Find( string Name );
		bool Exists( string Name );

	}
}
