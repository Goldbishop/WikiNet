using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IArticleContentRawRepository : IRepository<ArticleContentRaw> {
		ArticleContentRaw FindById( Guid id );
	}

	public class ArticleContentRawRepository:RepositoryBase<ArticleContentRaw>, IArticleContentRawRepository {
		#region IArticleContentRawRepository Members

		public ArticleContentRaw FindById( Guid id ) {
			return AllInformation()
				.Where( acr => acr.ArticleContentId == id )
					.SingleOrDefault();
		}

		#endregion

		#region IRepository<ArticleContentRaw> Members

		public void Add( ArticleContentRaw entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<ArticleContentRaw> AllInformation() {
			return Entity;
		}

		public void Delete( ArticleContentRaw entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<ArticleContentRaw> Find() {
			return Entity
				.ToList();
		}

		public IQueryable<ArticleContentRaw> FindAll() {
			return Entity;
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
