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

			Property( a => a.Id ).HasColumnName( "id" )
				.IsRequired()
				.HasDatabaseGeneratedOption( DatabaseGeneratedOption.Identity );
			Property( a => a.Name ).HasColumnName( "name" )
				.IsRequired().HasMaxLength( 25 );
			Property( a => a.NamespaceId ).HasColumnName( "NamespaceId" )
				.IsRequired();
			Property( a => a.CreatedById ).HasColumnName( "createdby" )
				.IsRequired();
			Property( a => a.CreatedOn ).HasColumnName( "createdon" )
				.IsRequired();
			Property( a => a.Active ).HasColumnName( "active" )
				.IsOptional();

			//TODO: Map Navigation Properties
			HasRequired( a => a.Content )
				.WithRequiredPrincipal( ac => ac.Article );
			HasRequired( a => a.CreatedBy )
				.WithMany( u => u.Articles )
				.HasForeignKey( a => a.CreatedById );
			HasRequired( a => a.Namespace )
				.WithMany( ns => ns.Articles )
				.HasForeignKey( a => a.NamespaceId );
			HasMany( a => a.History )
				.WithRequired( ac => ac.Article );

		}
	}

	public interface IArticle {
		Guid Id { get; set; }
		string Name { get; set; }
		int NamespaceId { get; set; }
		Guid CreatedById { get; set; }
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
