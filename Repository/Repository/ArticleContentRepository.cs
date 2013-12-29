using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IArticleContentRepository : IRepository<ArticleContent> {
		ArticleContent FindByArticle( Guid Id );
	}
	public class ArticleContentRepository : RepositoryBase<ArticleContent> , IArticleContentRepository {

		#region IArticleContentRepository Members

		public ArticleContent FindByArticle( Guid Id ) {
			return AllInformation()
				.Where( ac => ac.ArticleId == Id )
					.SingleOrDefault();
		}

		#endregion

		#region IRepository<ArticleContent> Members

		public void Add( ArticleContent entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<ArticleContent> AllInformation() {
			return Entity
				.Include( "User" )
				.Include( "Article" );
		}

		public void Delete( ArticleContent entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<ArticleContent> Find() {
			return FindAll().ToList();
		}

		public IQueryable<ArticleContent> FindAll() {
			return Entity;
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
