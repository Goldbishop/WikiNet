using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.EF {
	public class VersionRepository:RepositoryBase, IVersionRepository {
		public VersionRepository( WikiContext context ) : base( context ) { }
		#region IVersionRepository Members

		public IEnumerable<Version> Find( Guid id ) {
			return AllInformation()
				.Where( v => v.ArticleId == id );
		}

		public Version Find( Guid id , int number ) {
			return AllInformation()
				.Where( v => v.ArticleId == id && v.Number == number ).SingleOrDefault();
		}

		public IEnumerable<Version> Find( Article article ) {
			return AllInformation()
				.Where( v => v.Article == article );
		}

		#endregion

		#region IRepositoryBase<Version> Members

		public ObjectSet<Version> Entity {
			get { return Context.Versions; }
		}

		public void Save( Version entity ) {
			if( !Entity.Contains( entity ) )
				Entity.AddObject( entity );
		}

		public void Delete( Version entity ) {
			if( Entity.Contains( entity ) )
				Entity.DeleteObject( entity );
		}

		public IEnumerable<Version> AllInformation() {
			return Entity
				.Include( "Article" )
				.Include( "User" );
		}

		public IEnumerable<Version> FindAll() {
			return Entity
				.Include( "User" );
		}

		#endregion

	}

	public interface IVersionRepository:IRepositoryBase<Version> {
		IEnumerable<Version> Find( Guid id );
		Version Find( Guid id , int number );
		IEnumerable<Version> Find( Article article );

	}
}
