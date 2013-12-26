using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Wiki.Domain;

namespace Wiki.Repository {
	public class ArticleRepository:RepositoryBase, IArticleRepository {
		public ArticleRepository( WikiContext context ) : base( context ) { }

		#region IArticleRepository Members


		public Article Find( string name ) {
			return AllInformation()
				.Where( a => a.Name == name ).SingleOrDefault();
		}

		public bool Exists( string name ) {
			return FindAll()
				.Any( a => a.Name == name );
		}

		#endregion

		#region IRepositoryBase<Article> Members

		public ObjectSet<Article> Entity {
			get { return this.Context.Articles; }
		}

		public void Save( Article entity ) {
			if( !Entity.Contains( entity ) )
				Entity.AddObject( entity );
		}

		public void Delete( Article entity ) {
			if( Entity.Contains( entity ) )
				Entity.DeleteObject( entity );
		}

		public IEnumerable<Article> AllInformation() {
			return Entity
				.Include( "Versions" )
				.Include( "Namespace" )
				.Include( "CreatedUser" );
		}

		public IEnumerable<Article> FindAll() {
			return Entity
				.Include("Namespace");
		}

		#endregion
	}

	public interface IArticleRepository:IRepositoryBase<Article> {
		Article Find( string name );

		bool Exists( string name );
	}
}
