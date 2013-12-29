using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IArticleRepository : IRepository<Article> {
		Article FindByID( Guid id );

	}

	public class ArticleRepository : RepositoryBase<Article> , IArticleRepository {

		#region IArticleRepository Members

		public Article FindByID( Guid id ) {
			return AllInformation()
				.Where( a => a.Id == id )
					.SingleOrDefault();
		}

		#endregion

		#region IRepository<Article> Members

		public void Add( Article entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<Article> AllInformation() {
			return Entity
				.Include( "Content" );
		}

		public void Delete( Article entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<Article> Find() {
			return FindAll().ToList();
		}

		public IQueryable<Article> FindAll() {
			return Entity;
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
