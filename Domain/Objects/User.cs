using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class UserMap : DomainMap<User> {
		public UserMap() {
			ToTable( "User" );

			HasKey( u => u.Id );

			Property( u => u.Id ).HasColumnName( "id" )
				.HasDatabaseGeneratedOption( DatabaseGeneratedOption.Identity );
			Property( u => u.Display ).HasColumnName( "display" )
				.IsRequired();
			Property( u => u.Email ).HasColumnName( "email" )
				.IsRequired();
			Property( u => u.Verified ).HasColumnName( "verfied" );
			Property( u => u.RoleID ).HasColumnName( "RoleId" )
				.IsRequired();

			//TODO: Map Navigation Properties
			HasOptional( u => u.Details )
				.WithRequired( ud => ud.User );
			HasRequired( u => u.Role )
				.WithMany( r => r.Users );
			HasOptional( u => u.Articles );
		}
	}

	public interface IUser {
		Guid Id { get; set; }
		string Display { get; set; }
		string Email { get; set; }
		bool Verified { get; set; }
		Int16 RoleID { get; set; }

		//Navigation Properties
		UserDetails Details { get; set; }
		Role Role { get; set; }
		ICollection<Article> Articles { get; set; }
		ICollection<ArticleContent> Contribution { get; set; }
	}

	public class User : IUser {

		#region IUser Members

		public Guid Id { get; set; }
		public string Display { get; set; }
		public string Email { get; set; }
		public bool Verified { get; set; }
		public short RoleID { get; set; }

		//Navigation Properties
		public UserDetails Details { get; set; }
		public Role Role { get; set; }
		public ICollection<Article> Articles { get; set; }
		public ICollection<ArticleContent> Contribution { get; set; }
		#endregion
	}

}
