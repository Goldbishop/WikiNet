using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Wiki.Repository;

namespace Wiki.Service {
	public interface IArticleService {
		Article Create( int ns , string name , string title , string body , Guid userid );
		Article Edit( Guid id , string title , string body , Guid userid );
		void Delete( Guid id );
	}
	public class ArticleService:IArticleService {
		public ArticleService() { }

		public IArticleRepository ArticleRepository { get; set; }
		public IArticleContentRepository ArticleContentRepository {get;set;}

		#region IArticleService Members
		/// <summary>
		/// Created an Article from the content provided
		/// </summary>
		/// <param name="ns">The Namespace Id that the Article will reside</param>
		/// <param name="name">The Name of the Article</param>
		/// <param name="title">The Title of the Article</param>
		/// <param name="body">The Body of the Article</param>
		/// <param name="userid">The User Id who created the Article</param>
		/// <returns>The istance of the Article that was created</returns>
		public Article Create( int ns , string name , string title , string body , Guid userid ) {
			var now = DateTime.Now;

			var art = new Article() {
				NamespaceId = ns ,
				Name = name ,
				CreatedById = userid,
				CreatedOn = now,
				Active = true
			};

			ArticleRepository.Add( art );
			ArticleRepository.Save();

			var parsed = SyntaxHelper.Parse( body );

			//TODO: 
			var artdetails = new ArticleContent() {
				ArticleId = art.Id ,
				Title = title ,
				Body = parsed ,
				Version = now ,
				CreatedBy = userid
			};

			ArticleContentRepository.Add( artdetails );
			ArticleContentRepository.Save();

			var artdetailsraw = new ArticleContentRaw() {
				ArticleContentId = artdetails.Id,
				Body = body
			};
			

			return art;
		}
		/// <summary>
		/// Modifies the specified Article, by its <paramref name="id"/>
		/// </summary>
		/// <param name="id">The Article ID to edit</param>
		/// <param name="title">The New Title for the Article</param>
		/// <param name="body">The Body of the Article</param>
		/// <param name="userid">The User Id who made the edit</param>
		/// <returns></returns>
		public Article Edit( Guid id , string title , string body , Guid userid ) {
			var art = ArticleRepository.FindByID( id );

			var artdetails = new ArticleContent() {
				ArticleId = art.Id,
				Title = title ,
				Body = body ,
				CreatedBy = userid ,
				Version = DateTime.Now
			};

			ArticleContentRepository.Add( artdetails );
			ArticleContentRepository.Save();

			return art;
		}
		/// <summary>
		/// Deletes the specified Article, by its <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The Article Id to delete</param>
		/// <returns>
		/// True - Article was disabled
		/// False - Article does not exist and so was not disabled.
		/// </returns>
		public void Delete( Guid id ) {
			var art = ArticleRepository.FindByID( id );
			if( art != null ) {
				art.Active = false;

				ArticleRepository.Save();
			} 
		}

		#endregion
	}
}
