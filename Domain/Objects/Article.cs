using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class ArticleMap : DomainMap<Article> {
		public ArticleMap() {
			ToTable( "Article" );

			HasKey( a => a.Id );

			Property( a => a.Id ).HasColumnName( "id" );
			Property( a => a.Name ).HasColumnName( "name" );
			Property( a => a.NamespaceId ).HasColumnName( "NamespaceId" );
			Property( a => a.CreatedBy ).HasColumnName( "createdby" );
			Property( a => a.CreatedOn ).HasColumnName( "createdon" );

			//TODO: Map Navigation Properties
			HasRequired( a => a.Content )
				.WithRequiredPrincipal( ac => ac.Article );

		}
	}

	public interface IArticle {
		Guid Id { get; set; }
		string Name { get; set; }
		int NamespaceId { get; set; }
		Guid CreatedBy { get; set; }
		DateTime CreatedOn { get; set; }

		//Navigation Property
		Namespace Namespace { get; set; }
		User User { get; set; }
		ArticleContent Content { get; set; }
		ICollection<ArticleContent> History { get; set; }
	}

	public class Article : IArticle {

		#region IArticle Members

		public Guid Id { get; set; }
		public string Name { get; set; }
		public int NamespaceId { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }

		//Navigation properties
		public Namespace Namespace { get; set; }
		public User User { get; set; }	//This is associated with CreatedBy property
		public ArticleContent Content { get; set; }
		public ICollection<ArticleContent> History { get; set; }

		#endregion
	}

}
