using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class ArticleContentRawMap : DomainMap<ArticleContentRaw> {
		public ArticleContentRawMap() {
			ToTable( "Article_Content_Raw" );

			Property( acr => acr.ArticleContentId ).HasColumnName( "ArticleContentId" );
			Property( acr => acr.Body ).HasColumnName( "body" );

			HasRequired( acr => acr.ArticleContent )
				.WithRequiredPrincipal( ac => ac.Raw )
				.Map( x => x.MapKey( "ArticleContentId" ) );
		}
	}
	public interface IArticleContentRaw {
		Guid ArticleContentId { get; set; }
		string Body { get; set; }

		ArticleContent ArticleContent { get; set; }
	}
	public class ArticleContentRaw : IArticleContentRaw {
		#region IArticleContentRaw Members

		public Guid ArticleContentId { get; set; }
		public string Body { get; set; }

		public ArticleContent ArticleContent { get; set; }

		#endregion
	}
}
