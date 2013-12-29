using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class NamespaceMap : DomainMap<Namespace> {
		public NamespaceMap() {
			ToTable( "Namespace" );

			HasKey( n => n.Id );

			//Property-Table mapping
			Property( n => n.Id ).HasColumnName( "id" )
				.HasDatabaseGeneratedOption( DatabaseGeneratedOption.Identity );
			Property( n => n.Description ).HasColumnName( "description" );
			Property( n => n.Active ).HasColumnName( "active" );
			Property( n => n.Name ).HasColumnName( "name" )
				.IsRequired().HasMaxLength( 25 ) ;

			//Navigation Properties
			HasMany( n => n.Articles )
				.WithRequired( a => a.Namespace );

		}
	}

	public interface INamespace {
		Guid Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		bool Active { get; set; }

		ICollection<Article> Articles { get; set; }
		ICollection<RoleAccess> Access { get; set; }
	}

	public class Namespace : INamespace {

		public Namespace() {
			this.Articles = new HashSet<Article>();
		}

		#region INamespace Members

		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }

		public virtual ICollection<Article> Articles { get; set; }
		public virtual ICollection<RoleAccess> Access { get; set; }
		#endregion
	}

}
