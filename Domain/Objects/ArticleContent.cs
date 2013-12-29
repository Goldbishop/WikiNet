using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//URL: Refer to http://agilenet.wordpress.com/2011/04/11/entity-framework-4-1-rc-with-an-existing-database/
namespace Wiki.Domain {
	public class ArticleContentMap : DomainMap<ArticleContent> {
		public ArticleContentMap() {
			ToTable( "Article_Content" );

			HasKey( ac => new { ac.ArticleId , ac.Version } );

			Property( ac => ac.ArticleId ).HasColumnName( "ArticleId" );
			Property( ac => ac.Title ).HasColumnName( "title" )
				.IsRequired().HasMaxLength( 50 );
			Property( ac => ac.Body ).HasColumnName( "body" );
			Property( ac => ac.Version ).HasColumnName( "version" );
			Property( ac => ac.CreatedBy ).HasColumnName( "createdby" );

			//Navigation Properties
			HasRequired( ac => ac.User )
				.WithMany( u => u.Contribution )
				.HasForeignKey(ac => ac.CreatedBy);
			HasRequired( ac => ac.Article )
				.WithMany( a => a.History )
				.Map( x => x.MapKey( "ArticleId" ) );
		}
	}

	public interface IArticleContent {
		Guid ArticleId { get; set; }
		string Title { get; set; }
		string Body { get; set; }
		DateTime Version { get; set; }
		Guid CreatedBy { get; set; }

		//Navigation Properties
		User User { get; set; }
		Article Article { get; set; }
	}

	public class ArticleContent : IArticleContent {

		#region IArticleContent Members

		public Guid ArticleId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime Version { get; set; }
		public Guid CreatedBy { get; set; }

		//Navigation Properties
		public User User { get; set; }
		public Article Article { get; set; }

		#endregion
	}
}
